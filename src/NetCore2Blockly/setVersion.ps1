$TimeNow = Get-Date
$d = $TimeNow.ToUniversalTime()
$year = $TimeNow.Year
$startOfYear = Get-Date -Year $year -Month 1 -Day 1 -Hour 0 -Minute 0 -Second 0 -Millisecond 0

$diff = NEW-TIMESPAN -Start $startOfYear -End $TimeNow
#$diff.TotalSeconds -as [int]

$assemblyVersion=$d.ToString("1.yyyy.1MMdd.1HHmm")
dotnet-property "**/*.csproj" AssemblyVersion:"$assemblyVersion"
dotnet dotnet-property "**/*.csproj" AssemblyVersion:"$assemblyVersion"

$version=$d.ToString("1.0.yyyy.") + ($diff.TotalSeconds -as  [int]).ToString()
dotnet-property "**/*.csproj" Version:"$version"
dotnet dotnet-property "**/*.csproj" Version:"$version"

$releaseNotes = "BuildNumber $env:BUILD_BUILDNUMBER"
$releaseNotes += ";author $env:BUILD_SOURCEVERSIONAUTHOR"
$releaseNotes += ";message $env:BUILD_SOURCEVERSIONMESSAGE"
$releaseNotes +=";source for this release github.com/ignatandrei/webAPI2CLI/commit/$env:BUILD_SOURCEVERSION"

$releaseNotes

dotnet-property "**/*.csproj" PackageReleaseNotes:"$releaseNotes"
dotnet dotnet-property "**/*.csproj" PackageReleaseNotes:"$releaseNotes"
