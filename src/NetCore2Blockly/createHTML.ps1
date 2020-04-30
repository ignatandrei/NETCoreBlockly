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

Copy-Item $folder "NetCore2Blockly\NetCore2Blockly\blocklyFiles\" -Recurse
 
Write-Host "-====="
