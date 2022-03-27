window.sayHello = function(name) {
		console.log(name);
};


window.jsToolTips = {
	getHelperOfElement: function (element) {
		return helper = element.getElementsByClassName("ToolTip-Helper")[0];
	},
	updateHelperslocation: function (parent) {
		let parentRect = parent.getBoundingClientRect();
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
		else if (parentRect.right + helperWidth + 10 > window.innerWidth || parentRect.right + helperWidth + 10 >  document.body.clientWidth) {
			horizontalposition += "-left";
		}
		var position = verticalposition + horizontalposition;
		parent.setAttribute("data-helper-position", position);
	},
	makeHelperPositionResponsive: function (element) {
		if (element != null) {
			var listens = element.hasAttribute("data-is-reactive");
			if (listens === false) {
				element.addEventListener("mouseenter", event => {
					if (element.classList.contains("ToolTips-Active") || element.classList.contains("ToolTip-Toggler")) {
					let helper = this.getHelperOfElement(element);
					this.updateHelperslocation(element,helper);
				}
			});
			element.setAttribute("data-is-reactive", true);
			}
		}
	},
	makeHelperMarkupElementsResponsive: function () {
		let elements = document.querySelectorAll('[class*="Tool-Tip"]').querySelectorAll(':not(.ToolTip-Helper)');
		elements.foreach(element => this.makeHelperPositionResponsive(element));
	}

}; 
