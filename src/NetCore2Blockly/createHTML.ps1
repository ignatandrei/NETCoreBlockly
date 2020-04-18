
function GetStringBetweenTwoStrings($firstString, $secondString, $importPath){

    #Get content from file
    $file = Get-Content $importPath
	Write-Host $file 
	#$file = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
    #Regex pattern to compare two strings
[regex]$regex = 
@'
(?ms)doNotCopy:
(.+?)
endDoNotCopy:.+?   
'@;
$regex.Matches("$(Get-Content $importPath -Raw)") |
 foreach { $_.groups[1].value }{
	Write-Host $_
 }
    #Return result
    return 10

}
$myText =GetStringBetweenTwoStrings -firstString 'doNotCopy' -secondString 'endDoNotCopy' -importPath  ".\TestBlocklyHtml\wwwroot\blockly.html"
$myText =GetStringBetweenTwoStrings -firstString 'Lorem' -secondString 'is' -importPath  ".\TestBlocklyHtml\wwwroot\blockly.html"
Write-Host "-====="
Write-Host $myText
