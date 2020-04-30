$folder= ".\TestBlocklyHtml\wwwroot\"
$file = Join-Path -Path $folder -ChildPath "blockly.html"
$fileContent = Get-Content $file

$fileContent = $fileContent.Replace('<!--doNotCopyToFinal-->','<!--')
$fileContent = $fileContent.Replace('<!--enddoNotCopyToFinal-->','-->')
$fileContent = $fileContent.Replace('/*doNotCopyToFinal*/','/*')
$fileContent = $fileContent.Replace('/*enddoNotCopyToFinal*/','*/')

Out-File -InputObject $fileContent  -FilePath ".\TestBlocklyHtml\wwwroot\blockly.html"
$zipFile = "$folder\blocklyNetCore.zip"
$compress = @{
  Path = "$Folder"
  CompressionLevel = "Fastest"
  DestinationPath = $zipFile
}
Compress-Archive @compress

$dest ="NetCore2Blockly\blocklyFiles\"
Write-Host ( Get-ChildItem $dest -Recurse | Measure-Object ).Count;

$folder =$folder + "*"
Copy-Item -Path $folder -Destination $dest  -Recurse

Write-Host ( Get-ChildItem $dest -Recurse | Measure-Object ).Count;

$indexFile = Join-Path -Path $dest -ChildPath "index.html"
Remove-Item -Path $indexFile

Write-Host ( Get-ChildItem $dest -Recurse | Measure-Object ).Count;

Write-Host "done====="
