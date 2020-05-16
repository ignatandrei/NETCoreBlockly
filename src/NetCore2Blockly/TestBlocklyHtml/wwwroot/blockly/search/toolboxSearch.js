var resultsSearch = [];
function registerSearch(workspace){
workspace.registerToolboxCategoryCallback('SearchBlocks', function (workspace) {
	var t = workspace.getToolbox();
	//console.log(t.tree_);
	resultsSearch = [];
	var searchTerm = window.prompt('What to search ?');
	if (searchTerm)
		recursiveSearch(t.tree_, searchTerm);
	//window.alert(resultsSearch.length);
	return resultsSearch;
});
}
function recursiveSearch(child,searchstring) { //search the tree recursively
//console.log(child);
if (child.children_) { // check if children_ is not null
	for (var i=0; i<child.children_.length; i++) { //for each children
		recursiveSearch(child.children_[i],searchstring);
	}    
}; 
if ("blocks" in child) { 
try{
			// search the block array and the blocks attribute.
	for (var i = 0; i<child.blocks.length; i++) {
		var b= child.blocks[i];
		//if('type' in b)
		{
			var str=Blockly.Xml.domToText(b);
			if(str.toLowerCase().includes(searchstring.toLowerCase()))
					resultsSearch.push(child.blocks[i]);	
		}
			
	
	}
}
catch(e){
		}
}          
}