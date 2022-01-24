cls
$content = Get-Content -Path All.txt | ConvertFrom-Json 

foreach($val in $content  ) {

$file = $val.Id + ".txt" 

Write-Host 'process' $file 
$fileContent = [XML](Get-Content -Path $file)
$blocks = $fileContent.SelectNodes("//*[local-name () = 'block']") | Select -Unique  -ExpandProperty type  | Where { $_.StartsWith("variables") -eq $false }
$str =[String]::Join(';',$blocks)


$val | add-member -Name "blocks" -value $str -MemberType NoteProperty -Force



}

$content | ConvertTo-Json | Out-File "All.txt" -Encoding utf8