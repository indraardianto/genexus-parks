function CardSemantic($) {
	  
	  
	  
	  
	  
	  

	var template = '<div class=\"ui link cards\">	<div class=\"card\">	<div class=\"image\">	<img src=\"{{Photo}}\">	</div>	<div class=\"content\">	<div class=\"header\">{{Name}}</div>	<div class=\"meta\">	<a>{{AddedDate}}</a>	</div>	<div class=\"description\">	{{Address}}	</div>	</div>	<div class=\"extra content\">	<span class=\"right floated\">	{{Email}}	</span>	<span>	<i class=\"user icon\"></i>	{{Phone}}	</span>	</div> </div>';
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();



			// Raise after show scripts

	}

	this.Scripts = [];




	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}