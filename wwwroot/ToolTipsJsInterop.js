// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function sayHello(message) {
  console.log(message);
}

export function findToolTipAnchorsByContent(content) {
	for (i = 0; i < content.lenth; i++) {
		console.log(content[i]);
	}
}


export function findlocation(id) {
	let element = document.getElementById(id);
	let helper = element.getElementsByClassName("ToolTip-Helper");
	let elementRect = element.getBoundingClientRect();
	let helperRect = helper.getBoundingClientRect();
	var helperHeight = helperRect.bottom-helperRect.top;
	var helperWidth = helperRect.right - helperRect.left;
	var verticalposition = "top";
	var horizontalposition = "";
	if (elementRect.bottom + helperHeight < (window.innerHeight || document.documentElement.clientHeight)) {
		verticalposition = "bottom";
	}
	if (elementRect.left - helperWidth < 0) {
		horizontal += "-right";
	}
	else if (elementRect.left - helperWidth < 0) {
		horizontal += "-left";
	}
	return verticalposition + horizontalposition;
}