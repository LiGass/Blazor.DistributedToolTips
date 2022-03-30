

window.jsToolTips = {
	getHelperOfElement: function (element) {
		return helper = element.getElementsByClassName("ToolTip-Helper")[0];
	},
	updateHelperlocation: function (parent) {
		let parentRect = parent.getBoundingClientRect();
		let helperRect = parent.getElementsByClassName("ToolTip-Helper")[0].getBoundingClientRect();
		var helperHeight = helperRect.bottom - helperRect.top;
		var helperWidth = helperRect.right - helperRect.left;
		var verticalposition = "top";
		var horizontalposition = "";

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
			if (!element.hasAttribute("data-is-reactive")) {
				element.addEventListener("mouseenter", event => {
					if (element.getAttribute("data-tooltip") =="displayed" || element.classList.contains("ToolTip-Toggler")) {
						let helper = this.getHelperOfElement(element);
						this.updateHelperlocation(element,helper);
					}
				});
				element.setAttribute("data-is-reactive", true);
				if (element.classList.contains("ToolTip-Toggler")) {
					element.setAttribute("data-tooltip", "displayed");
				}
				return true;
			}
			return false;
		}
	},
	initializeMarkups: function (parent) {
		let elements = parent.querySelectorAll('.ToolTip-Anchor');
		if (elements.length > 0) {
			for (var i = 0; i < elements.length; i++) {
				if (!elements[i].hasAttribute("data-tooltip")) {
					this.makeHelperPositionResponsive(elements[i]);
					elements[i].setAttribute("data-tooltip", "hidden");
				}
			}
		}
	},
	updateMarkups: function (parent, displayed) {
		let elements = parent.querySelectorAll('.ToolTip-Anchor');
		for (var i = 0; i < elements.length; i++) {
			if (displayed == true) {
				elements[i].setAttribute("data-tooltip", "displayed");
			} else {
				elements[i].setAttribute("data-tooltip", "hidden");
			}
		}
	}

}; 