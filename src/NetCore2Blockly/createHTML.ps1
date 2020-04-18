$folder= ".\TestBlocklyHtml\wwwroot"
$fileContent = Get-Content "$folder\blockly.html"

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

 
Write-Host "-====="
