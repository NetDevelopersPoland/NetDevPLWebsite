#$openCover = Get-ChildItem -Path "C:\Users\$([Environment]::UserName)\.nuget\packages\" -Filter "OpenCover.Console.exe" -Recurse | % { $_.FullName }
#$xUnit = Get-ChildItem -Path "C:\Users\$([Environment]::UserName)\.nuget\packages\" -Filter "xunit.console.exe" -Recurse | % { $_.FullName }

$openCover = "packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"
$openCoverProfiler = "packages\OpenCover.4.6.519\tools\x86\OpenCover.Profiler.dll"
$xUnit = "packages\xunit.runner.console.2.1.0\tools\xunit.console.exe"

# entry folder
$root = "artifacts\"
$coverageFile = $root + "NetDevPL_coverage.xml"

# test projects to run with OpenCover
$projects = @(
    @{Path="NetDevPL.Features.NetGroups.IntegrationTests.dll"; Filter="+[NetDevPL*]*"}
)

function RunCodeCoverage($testProject, $filter) {
        & $openCover -register:user "`"-target:$xUnit`"" "`"-targetargs:$testProject -noshadow -appveyor`""  "-filter:$filter" -output:"$coverageFile" -hideskipped:All -mergeoutput -oldStyle -returntargetcode
}

# run unit tests and calculate code coverage for each test project
foreach ($project in $projects) {
    RunCodeCoverage $($root + $project.Path) "+[NetDevPL*]*" #$project.Filter
}

# try to find error
if($LastExitCode -ne 0)
{
   # mark build as failed
   #$host.SetShouldExit($LastExitCode)
   
   Write-Host $LastExitCode
}
