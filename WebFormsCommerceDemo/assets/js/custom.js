(function ($) {
	"use strict";

	// TOOLTIP	
	$(".header-links .fa, .tool-tip").tooltip({
		placement: "bottom"
	});
	$(".btn-wishlist, .btn-compare, .display .fa").tooltip('hide');

	// TABS
	$('.nav-tabs a').click(function (e) {
		e.preventDefault();
		$(this).tab('show');
	});

	$('input#txtSearch').keypress(function (e) {
		if (e.keyCode === 13) __doPostBack('ctl00$ctl00$btnSearch', '');
	});

	if($('div#Viewport_MainContent_vwAddedCart').hasClass('alert-success')){
		$('div#vwCart').addClass('open');
	}
})(jQuery);

