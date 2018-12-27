var Ariana = Ariana || {};

(function($, jQuery) {
	'use strict';

	Ariana.TopNavigation = function(options) {
		function initTopNavigation(){
			$('#topNavigation .handle').on('click', function(){
				 $('#topNavigation .dropdown').toggleClass('mobile');
				 $('#topNavigation ul').toggle();
			});

			var $dropdownButton = $('#topNavigation .dropdown');
			var $dropdownContent = $('#topNavigation .dropdown-content');

			console.log('testsss');

			console.log($dropdownButton);
			console.log($dropdownContent);

			$dropdownButton.on('click', function(){
				


				// Check if mobile device
				var $menuIcon = $('.menu-icon');
				if($menuIcon.is(':visible') == true){
					console.log('logg');
					$dropdownContent.toggle();
				}

			});


			// $('#topNavigation .dropdown.mobile').find('.dropbtn').click('onClick', function(){
			// 	console.log('clicked');
			// 	$('#topNavigation .dropdown-content').toggle();
			// });

			$('#topNavigation .dropdown.mobile').find('.dropbtn').click('onClick', function(){ console.log('test') });
		}


		function __construct(){
			initTopNavigation();
		}

		__construct();

		return;

		
	};

	
	
})(jQuery, jQuery);

