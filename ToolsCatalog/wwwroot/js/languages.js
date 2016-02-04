// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function LanguagesIndex(){

	function LanguagesIndexViewModel() {
		var self = this;
		$.ajax({ url: "/Languages/GetLanguages", method: "GET", contentType: "json" })
			.then(function (data) {
				data.forEach(function (item) {
					self.languages.push(item);
				});
			}, function (err) {
				alert("Error: " + err);
		});

		this.languages = ko.observableArray([]);
		this.firstName = "Bert";
		this.lastName = "Bertington";
	}

	// Activates knockout.js
	ko.applyBindings(new LanguagesIndexViewModel());
}