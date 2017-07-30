using System.Collections.Generic;
using System.Linq;
using NetDevPL.Features.Facebook;

namespace NetDevPL.Features.Reporting
{
    public class FacebookStats
    {
        public List<UserKarma> UserKarma()
        {
            Repository repository = new Repository();

            var users = repository.UsersGetList();
            var likesGrouped = repository.LikesGetList().GroupBy(l => l.UserId).ToList();
            var commentsGrouped = repository.CommentsGetList().GroupBy(l => l.UserId).ToList();

            return users.Select(u => new UserKarma
            {
                Name = u.Name,
                LinesCount = likesGrouped.Any(lg => lg.Key == u.Id) ? likesGrouped.FirstOrDefault(lg => lg.Key == u.Id).ToList().Count : 0,
                CommentsCount = commentsGrouped.Any(lg => lg.Key == u.Id) ? commentsGrouped.FirstOrDefault(lg => lg.Key == u.Id).ToList().Count : 0
            })
                .OrderByDescending(k => k.LinesCount)
                .ToList();
        }
    }
}