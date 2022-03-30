// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function sayHello(message) {
  console.log(message);
}
export function addJavascriptEvent(element) {
	if (element != null) {
		var listens = element.hasAttribute("data-reactive-tooltip");
		if (listens === false) {
			element.addEventListener("mouseenter", event => {
				if (element.classList.contains("ToolTip-Toggler") || element.getAttribute("data-tooltip")=="visible") {
					updateHelperlocation(element);
				}
			});
			element.setAttribute("data-reactive-tooltip", true);
		}
	}
}
function updateHelperlocation(parent) {
	let parentRect = parent.getBoundingClientRect();
	try {
		let helperRect = parent.getElementsByClassName("ToolTip-Helper")[0].getBoundingClientRect();
		var helperHeight = helperRect.bottom - helperRect.top;
		var helperWidth = helperRect.right - helperRect.left;
		var verticalposition = "top";
		var horizontalposition = "";
		console.log(parentRect.right + helperWidth + 10 > window.innerWidth || parentRect.right + helperWidth + 10 > document.body.clientWidth);

		if (parentRect.top - helperHeight < 10) {
			verticalposition = "bottom";
		}
		if (parentRect.left - helperWidth < 10) {
			horizontalposition += "-right";
		}
		else if (parentRect.right + helperWidth + 10 > window.innerWidth || parentRect.right + helperWidth + 10 > document.body.clientWidth) {
			horizontalposition += "-left";
		}
		var position = verticalposition + horizontalposition;
		parent.setAttribute("data-helper-position", position);
	}
}