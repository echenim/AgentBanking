
var version = navigator.appVersion;

//ERROR VALIDATION HANDLERS CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function radio(elementName){
//	$('.error'+elementName).append("<div id='info"+elementName+"'></div>");
//	var nameInfo = $('#info'+elementName);
	var nameInfo = $('.error'+elementName);

	if(!$("input[name='"+elementName+"']:checked").val()) {
		errors = true;
		nameInfo.html('check a box').show();
	} else {
		nameInfo.html('').show();
	}
}

function alphabets(elementId){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var patt = /^[a-zA-Z]+$/;

	if(!patt.test(ele.val())) {
		errors = true;
		nameInfo.html('&larr; field empty / invalid entry').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	}
}

function varchar(elementId){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);

	if(ele.val() == "") {
		errors = true;
		nameInfo.html('&larr; field empty / invalid entry').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	}
}

function email(elementId){
//	$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	var nameInfo = $('#info'+elementId);
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var patt = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);

	if(!patt.test(ele.val())) {
		errors = true;
		nameInfo.html('&larr; field empty / invalid email format').show();
		ele.removeClass('normal').addClass('wrong');
	}else if(ele.val().indexOf("students.biu.edu.ng") > 0) {
		errors = true;
		nameInfo.html('&larr; you cannot use the schools given email address'+ele.val().indexOf("students.biu.edu.ng")).show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	}
}

function nameCode(elementId, codeArray){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var searchString = ele.val().toLowerCase();
	if (codeArray == undefined || codeArray == null || codeArray.length == 0 || (codeArray.length == 1 && codeArray[0] == "")){
		var lowerCodeArray = codeArray;
	}else{
		var lowerCodeArray = $.map(codeArray, function(item, index) {
			return item.toLowerCase();
		});
	}
//	var lowerCodeArray = codeArray;
//	var lowerCodeArray = $.each(codeArray, function(index, item) {codeArray[index] = item.toUpperCase();});
//	var lowerCodeArray = array.map(function(codeArray) { return codeArray.toLowerCase(); });
//	var lowerCodeArray = $.map(array, String.toLowerCase);
	var found = $.inArray(searchString, lowerCodeArray) > -1;
	
	if(found){
		errors = true;
		nameInfo.html('&larr; already exist').show();
		ele.removeClass('normal').addClass('wrong');
	}else if(ele.val().length < 3) {
		errors = true;
		nameInfo.html('&larr; at least 3 characters').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	}
}

function date(elementId){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var patt = /^[0-9]{4}\-[0-9]{2}\-[0-9]{2}$/i;

	if(!patt.test(ele.val())) {
		errors = true;
		nameInfo.html('&larr; not a valid date').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	} 
}

function dropDown(elementId){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);

	if(ele.val() == 0 || ele.val() == "") {
		errors = true;
		nameInfo.html('&larr; select an option').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	} 
}

function numbers(elementId){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var patt = /^[0-9]+(\.[0-9]{1,2})?$/;

	if(!patt.test(ele.val())) {
		errors = true;
		nameInfo.html('&larr; field empty / invalid entry').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.html('').show();
	}
}

function timer(elementId){
	//$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
	//var nameInfo = $('#info'+elementId);
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);

	if(ele.val() == "") {
		errors = true;
		nameInfo.html('&larr; field empty / invalid entry').show();
		ele.removeClass('normal').addClass('wrong');
//	}else if(ele.val() > number) {
//		errors = true;
//		nameInfo.html('&larr; max value '+number).show();
//		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.fadeOut();
	}
}

function equalCompare(elementId, elementCompId, notice){
//	if (!$('#info'+elementId).length){
//		$('.error'+elementId).append("<div id='info"+elementId+"'></div>");
//	}
	var nameInfo = $('.error'+elementId).css( "display", "block" );
	var ele = $('#'+elementId);
	var eleComp = $('#'+elementCompId);
	var elementVal = ele.val();
	var elementCompVal = eleComp.val();
	
	if(elementVal == 0 || elementVal == "") {
		errors = true;
		nameInfo.html('&larr; field empty / invalid entry').show();
		ele.removeClass('normal').addClass('wrong');
	}else if(elementVal !== elementCompVal) {
		errors = true;
		nameInfo.html('&larr; '+notice+' not equal').show();
		ele.removeClass('normal').addClass('wrong');
	} else {
		nameInfo.fadeOut();
	}
}

function editPayment(tagId, receiptId, amountTag, remainTag, totalVal){
	$('.numeric-textbox').bind("cut copy paste",function(e) {
		e.preventDefault();
	});

	$("#"+amountTag).keypress(function (e) {
		//if the letter is not digit then display error and don't type anything
		if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
			//display error message
			$(".error"+amountTag).html(" &larr; digits only").fadeIn().delay(1500).fadeOut("slow");
			return false;
		}
	});
   
	$("#"+tagId).change(function(){
		var stateId = $('option:selected', $(this)).val();
		//var stateId = $('#'+tagId+' option:selected').val();
		//var stateId = $("#"+tagId).val();
		//alert(stateId);
		if (stateId == 1){
			$("#"+remainTag).val(0);
			$("#"+amountTag).val(totalVal);
			$("#"+amountTag).attr("readonly", true);
		}else{
			$("#"+amountTag).attr("readonly", false);
			$("#"+amountTag).keyup(function(){
				var amountVal = $("#"+amountTag).val();
				var remainVal = totalVal - amountVal;
				if (remainVal < 2000){
					$(".error"+amountTag).html(" &larr; less than 2,000").fadeIn().delay(1500).fadeOut("slow");
					return false;
				}else{
					$("#"+remainTag).val(remainVal);
				}
			});
		}
	});

}

function comfirmEditPayment(amountTag, balTag, totalVal, receiptId){
	var receipt = $("#"+receiptId).val();
	var amountVal = $("#"+amountTag).val();
	var balVal = $("#"+balTag).val();
	var remainVal = totalVal - amountVal;
	if (receipt == '' || amountVal == '' || remainVal <= -1 || (remainVal > 0 && remainVal < 2000)){
		errors = true;
		$(".errorAll h6").html(" Note: All '*' field must be filled and Balance payment must not be less than N2,000 if the part payment option is selected").fadeIn().delay(2500).fadeOut("slow");
	} else {
		$(".errorAll h6").html('');
	}
}
	
	
//SUBMIT FUNCTION CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function loggedinstyle(){
	$('.topMenu').css( "margin-right", "10px" );
	$('html').css( "background-image", "none" );
	$('#wrapper').css( "background-image", "none" );
	$('#bodyWrapper').css( "position", "fixed" );
	$('#bodyWrapper').css( "overflow-y", "auto" );
	$('#bodyWrapper').css( "height", "100%" );
	$('.default, footer').hide(); 
	$(".dashboard").show();
	$('#logo').addClass('resizeLogo');
	$('header').addClass('Colour-Emerald');
}

function getUrlResponse(url, elementId, status){
	if (status == 'send'){
//		var sender = $('#sender').val();
//		var recipient = $('#recipient').val();
//		var message = $('#message').val();
//		var url = url+'&sender='+sender+'&recipient='+recipient+'&message='+message;
		$.ajax({
			url: url,
			type: 'GET',
			success: function(res) {
				var content = $(res.responseText).text();
				if (content == '2905'){
					errors = true;
					$('#credit').addClass('text-Red');
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'Invalid Username/Password';
				}else if(content == '2906'){
					errors = true;
					$('#credit').addClass('text-Red');
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'Credit Exhausted';
				}else if(content == '2904'){
					errors = true;
					$('#credit').addClass('text-Red');
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'SMS Sending Failed';
				}else if(content == '2907'){
					errors = true;
					$('#credit').addClass('text-Red');
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'Gateway Unavailable';
				}else if(content == '2908'){
					errors = true;
					$('#credit').addClass('text-Red');
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'Invalid schedule date format';
				}else if(content == '2909'){
					$('#credit').addClass('Colour-Red');
					errors = true;
					$(".noticeImg").attr("src","_images/_button/delete30.png");
					content = 'Unable to schedule';
//				}else if(content.toLowerCase().indexOf("ok")){
//					$('#credit').addClass('text-Green');
//					content = 'SMS was Sent Successfully! '+content;
				}else{
					$('#credit').addClass('text-Green');
				}
				$('#'+elementId).html(content);
				//alert(content);
			}
		});
	}
}

function gotoURL(page, action, id){
	showLoader();
	url = encodeURI("index.php?page="+page+"&action="+action+"&id="+id);
	window.location.replace(url);
}

function submitform(formname, elementId, page){
	var nameInfo = $('.error'+elementId);
	var formData = $('form#'+formname).serialize();
	$.ajax({
		type: "POST",
		url: "popLoader.php?page="+elementId,
		data: formData,
		dataType: 'json',
		beforeSend: showLoader(),
		//complete: hideLoader(),
		success: function(response){
			if(page == 0){
				if (response == 0){
					nameInfo.html('&larr; incorrect sign-in details').show();
					hideLoader();
				}else{
					window.location.replace("index.php?page=dashboard");
//					url = encodeURI("popLoader.php?page=dashboard");
//					$("#wrapper").load(url);
//					hideLoader();
//					$("#loadPage").empty().fadeOut();
				}
			}else if(page == 1){
				if (response == 0){
					nameInfo.html('&larr; duplicate email sign-up!').show();
					hideLoader();
				}else if (response == 1){
					nameInfo.html('&larr; matric-no does not exist!').show();
					hideLoader();
				}else if (response == 2){
					nameInfo.html('&larr; duplicate matric-no sign-up!').show();
					hideLoader();
				}else if (response == 3){
					nameInfo.html('&larr; student category does not match!').show();
					hideLoader();
				}else{
					$('.signupForm h2').html('Member Registration Successful!');
					$('.signupForm h5').html('Thank you for Signing Up on BIU Alumni Portal. Your Sign In details and User ID will be sent to your registered email address. Take the User-ID to the bank which will be used for your Alumni payment process which will inturn activate your Sign In details. Sign In and print your proof of payment. Have fun, Bye!');
					$('.signupForm input, .signupForm select').attr("disabled","disabled");
					$('.signupForm select').hide();
					$('#'+elementId+', .termsRadioBtn').hide();
					hideLoader();
				}
			}else{
				alert('404 Error!');
			}
		}
	})
}

//PRESS ENTER KEY CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function pressEnterKey(elementId){
	$('body').bind('keypress',function (event){
		if(event.keyCode==13 || e.which === 13){
	   		$('#'+elementId).click();
		}
	});
}

//PROFILE VALIDATE CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function validate(elementId){
	ele = $('#'+elementId).val();
	
	$('html').css( "overflow", "hidden" );
	showLoader();
	url = encodeURI("popLoader.php?page=profile&action=validate&id="+ele);
	$("#loadPage").empty().load(url,function(response,status,xhr){
		if(status=="error"){
			alert("Error: "+xhr.status+": "+xhr.statusText);
		}else{
			hideLoader();
			$("#loadPage").fadeIn();
		}
	});
}

//SHOW PRELOADER IMAGE WITH BG CS CONTROLLER SCRIPT---------------------------------------------------------------------------------

function showLoader(){
	$("#preLoader").fadeIn();
}

//HIDE PRELOADER IMAGE CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function hideLoader(){
	$("#preLoader").fadeOut();
}

//PAGINATOR CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function paginator(){
	$('.paginator').click(function(e){
		var id = $(this).attr('data-id');
		var bid = $(this).attr('data-bid');
		var rel = $(this).attr('data-rel');
		var view = $(this).attr('data-view');
		showLoader();
		url = encodeURI("index.php?page="+rel+"&action="+bid+"&pageNum="+id+"&id="+view);
		window.location.replace(url);
	});
}

function pageEntry(){
	$('#entry').change(function(e){
		var entry = $("#entry option:selected").val();
		var id = $(this).attr('data-id');
		var bid = $(this).attr('data-bid');
		var rel = $(this).attr('data-rel');
		showLoader();
		url = encodeURI("index.php?page="+rel+"&action="+bid+"&entry="+entry+"&id="+id);
		window.location.replace(url);
	});
}

function selectAll(){
	$('#selectAll, #selectAllMobile').click(function(){
		if($(this).prop("checked")) {
			$(".checkBoxClass").prop("checked", true);
		} else {
			$(".checkBoxClass").prop("checked", false);
		}                
	});
}

//PRINTER CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

//function printer(page, action, id){
//	$("#print").printPage({
//		url: "popLoader.php?page="+page+"&action="+action+"&id="+id,
//		attr: "href",
//		message:"Your document is being created"
//	});	
//	return false;
//}

//DOWNLOAD CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function downloader(){
	$('#csv').click(function(e){
		var bid = $(this).attr('data-bid');
		var rel = $(this).attr('data-rel');	
		url = encodeURI("index.php?page="+rel+"&action="+bid);
		$("#ifrmChild").hide().fadeIn('slow').attr("src", url);
	});
}

//TEST TIMER CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function reloader(){
	$('.reload').click(function(e){
		showLoader();
		location.reload().hideLoader();
	});
}

function countDownTimer(countDownTime, criticalTime){
	window.globalVar = criticalTime;
//	alert (countDownTime+' - '+criticalTime);
//	watchCountdown(periods);
//	if (countDownTime <= criticalTime){
//		$('#timer').removeClass('text-Gray');
//		$('#timer').addClass('text-Red');
//	}
	$('#timer').countdown({until: '+'+countDownTime+'s', onExpiry: submitQuestions, onTick: watchCountDown, format: 'HMS'});
	$('#topTimer').countdown({until: '+'+countDownTime+'s', onExpiry: submitQuestions, compact:true, onTick: watchCountDownTop, format: 'HMS'});
}

function watchCountDown(periods) { 
	//alert (periods[5]+' - '+criticalTime);
	if (periods[5] == globalVar && periods[6] == 0){
		//alert(globalVar);
		$('#timer').removeClass('text-Gray');
		setInterval(function(){
    		$("#timer").toggleClass("text-Red");
		},500)		
	}
}

function watchCountDownTop(periods) { 
	if (periods[5] == globalVar && periods[6] == 0){
		$('#topTimer').removeClass('text-White');
		setInterval(function(){
    		$("#topTimer").toggleClass("text-Orange");
		},500)		
	}
}
 
function submitQuestions(title, text, status) { 

	createModalBox(title, text);
	closeOverlap();		
	$(".testMenu").fadeOut();
	if (status == 1){
		$('.confirmBtn').click(function(e){
			$('.anchor').css( "display", "none" );
			$('.testMenu li').removeClass('anchor');
			$("#loadPage").empty().fadeOut();
			var formData = $('form#record').serialize();
			$.ajax({
				type: "POST",
				url: "popLoader.php?page=checkit&action=submit",
				data: formData,
				beforeSend: showLoader(),
				//complete: hideLoader(),
				success: function(response){
					if (response == 7){
						url = encodeURI("popLoader.php?page=checkit&action=score&id=1");
						$("#contentWrapper").fadeIn().load(url,function(response,status,xhr){
							if(status=="error"){
								alert("Error: "+xhr.status+": "+xhr.statusText);
							}else{
								hideLoader();
							}
						});
					}else{
						hideLoader();
						$("#loadPage").empty().fadeOut();
						createModalBox('No Network Connection!', 'Sorry! your network connection is bad, please click on the CLOSE/CANCEL button and try again.');
						$('.confirmBtn').css( "display", "none" );
						closeOverlap();		
					}
				}
			});
		});
	}else{
		$("#loadPage").empty().fadeOut();
		$('.anchor').css( "display", "none" );
		$('.testMenu li').removeClass('anchor');
		var formData = $('form#record').serialize();
		$.ajax({
			type: "POST",
			url: "popLoader.php?page=checkit&action=submit",
			data: formData,
			beforeSend: showLoader(),
			//complete: hideLoader(),
			success: function(response){
				if (response == 7){
					url = encodeURI("popLoader.php?page=checkit&action=score&id=1");
					$("#contentWrapper").fadeIn().load(url,function(response,status,xhr){
						if(status=="error"){
							alert("Error: "+xhr.status+": "+xhr.statusText);
						}else{
							hideLoader();
						}
					});
				}else{
					hideLoader();
					$("#loadPage").empty().fadeOut();
					createModalBox('No Network Connection!', 'Sorry! your network connection is bad, please click on the CONFIRM button and try again.');
					$('.confirmBtn').css( "display", "none" );
					closeOverlap();		
				}
			}
		});
	}
}

//ADD / REMOVE EXTRA PRODUCT FORM CS CONTROLLER SCRIPT----------------------------------------------------------------

function addQuestionField(className){
	var addCount = $('.'+className).length;
	//addCount += 1;
	var newContent =  '<tr class="obj slideEle0 addField'+addCount+'"><input type="hidden" id="ansOpt'+addCount+'" name="ansOpt[]" value="'+addCount+'"><td class="mHolder"><h5>ANSWER '+addCount+':</h5></td><td class="lHolder"><input type="text" value="" class="text" required name="ans'+addCount+'" id="ans'+addCount+'" placeholder="Answer '+addCount+'"><label class="text-Red italic errorans'+addCount+'">*</label></td><td class="miniHolder"><input type="radio" id="selectans'+addCount+'" name="selectans" value="'+addCount+'" /><label class="" for="selectans'+addCount+'"></label></td></tr>';
	$("#optionField").append(newContent);
	return false;
}

function removeQuestionField(className){
	var count = $('.'+className).length;
	count = count - 1;
	if (count > 2){
		$(".addField"+count).remove();
		return false;
	}else if (count == 2){
		alert("No more field to remove");
		return false;
	}
}

//ANCHORS CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function anchorer(totalPage){
	var count = 1;
	$('.anchor').click(function(e){
		var bid = $(this).attr('data-bid');
		var view = $(this).attr('data-view');
		var id = $(this).attr('data-id');
		
		if(bid == 'first'){
			count = 1;
			divId = view+count;
			$('.slide').slideUp();
			$('#'+divId).slideDown();
			$('.testMenu b').html(count);
		} else if(bid == 'previous'){
			if(count == 1){
				return false;
			}else{
				count -= 1;
				divId = view+count;
				$('.slide').slideUp();
				$('#'+divId).slideDown();
				$('.testMenu b').html(count);
			}
		}else if(bid == 'next'){
			if(count == totalPage){
				return false;
			}else{
				count += 1;
				divId = view+count;
				$('.slide').slideUp();
				$('#'+divId).slideDown();
				$('.testMenu b').html(count);
			}
		}else if(bid == 'last'){
			count = totalPage;
			divId = view+count;
				$('.slide').slideUp();
				$('#'+divId).slideDown();
				$('.testMenu b').html(count);
		}else{
			return false;
		}
	});
}


//CLOSE CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function closeOverlap(){
	$('.close, .cancelBtn, #cancelRecordBtn').click(function(e){
		$("#loadPage").empty().fadeOut();
		$(".testMenu").fadeIn();
	});
}

//LINKS CS MODALBOX AND ACTION LINK SCRIPT------------------------------------------------------------------------------------

function linker(elementId, page, action, id, status){
//	var bid = $(this).attr('data-bid');
//	var id = $(this).attr('data-id');
//	var rel = $(this).attr('data-rel');
	if (status == '0'){
		$("#"+elementId).empty().hide();
		$('html').css("overflow", "hidden");
	}
		
	showLoader();
	url = encodeURI("popLoader.php?page="+page+"&action="+action+"&id="+id);
	$("#"+elementId).load(url,function(response,status,xhr){
		if(status=="error"){
			alert("Error: "+xhr.status+": "+xhr.statusText);
		}else{
			hideLoader();
			if (status == '0'){
				$("#"+elementId).fadeIn();
			}
			//$("#outputDisplay").focus();
			//$('.centerAlignOverlap').slideDown(300);
		}
	});
}
 
function writeTest(elementId, page, action, id, notice) { 

	$.ajax({
		type: "POST",
		url: "popLoader.php?page="+page+"&action=validate&id="+id,
		beforeSend: showLoader(),
		//complete: hideLoader(),
		success: function(response){
			if (response == 1){
				url = encodeURI("popLoader.php?page="+page+"&action=introduction&notice="+notice);
				$("#"+elementId).fadeIn().load(url,function(response,status,xhr){
					if(status=="error"){
						alert("Error: "+xhr.status+": "+xhr.statusText);
					}else{
						hideLoader();
					}
				});
			}else{
				url = encodeURI("popLoader.php?page="+page+"&action="+action+"&id="+id);
				$("#"+elementId).fadeIn().load(url,function(response,status,xhr){
					if(status=="error"){
						alert("Error: "+xhr.status+": "+xhr.statusText);
					}else{
						hideLoader();
					}
				});
			}
		}
	});
} 

function displayForm(rel, bid, view, id, status){	
	$('html').css( "overflow", "hidden" );
	if(status == 'sms'){
		var groupPhoneNum = ''; 
		if($("input[name='"+id+"[]']").is(':checkbox')) {
			var arr = $("input[name='"+id+"[]']:checked").map(function(){
				return this.value;
			}).get();
			$.each(arr , function(i, val) { 
				var phoneNum = $('#phoneCheck'+arr [i]).val();
				groupPhoneNum = groupPhoneNum.concat(phoneNum+',');
			});
			id = groupPhoneNum.slice(0,-1); 
		}else{
			id = $('#phoneCheck'+id).val();
		}
	}else if(status == 'group'){
		var groupElementId = ''; 
		if($("input[name='"+id+"[]']").is(':checkbox')) {
			var arr = $("input[name='"+id+"[]']:checked").map(function(){
				return this.value;
			}).get();
			$.each(arr , function(i, val) { 
				var elementId = $('#checkbox'+arr [i]).val();
				groupElementId = groupElementId.concat(elementId+',');
			});
			id = groupElementId.slice(0,-1); 
		}else{
			id = $('#checkbox'+id).val();
		}
	}
	
	showLoader();
	url = encodeURI("popLoader.php?page="+rel+"&action="+bid+"&view="+view+"&id="+id);
	$("#loadPage").empty().load(url,function(response,status,xhr){
		if(status=="error"){
			alert("Error: "+xhr.status+": "+xhr.statusText);
		}else{
			hideLoader();
			$("#loadPage").fadeIn();
		}
	});
}

function actionForm(rel, bid, view, page, id, notice){
	var formData = $('form#record').serialize();
	$("#loadPage").empty().fadeOut();
	$.ajax({
		type: "POST",
		url: "popLoader.php?page="+rel+"&action="+bid+"&id="+id,
		data: formData,
		dataType: 'html',
		beforeSend: showLoader(),
		//complete: hideLoader(),
		success: function(response){
			url = encodeURI("index.php?page="+rel+"&action="+view+"&id="+id+"&pageNum="+page+"&notice="+notice);
			if(response==1){
				window.location.replace(url);
			}else{
				alert("Error: "+xhr.status+": "+xhr.statusText);
				//$("#alertShow").delay(100).fadeIn('slow').html("Record "+id+" Deleted Successfully!").delay(1300).fadeOut('slow');
			}
		}
	});
}

function actionMan(rel, bid, view, page, id, notice, title, text, displayForm){	
	createModalBox(title, text);
	closeOverlap();		
	$('.confirmBtn').click(function(e){
		var formData = $('form#'+displayForm).serialize();
		$("#loadPage").empty().fadeOut();
		$.ajax({
			type: "POST",
			url: "popLoader.php?page="+rel+"&action="+bid+"&id="+id,
			data: formData,
			dataType: 'html',
			beforeSend: showLoader(),
			//complete: hideLoader(),
			success: function(response){
				url = encodeURI("index.php?page="+rel+"&action="+view+"&id="+id+"&pageNum="+page+"&notice="+notice);
				if(response==1){
					window.location.replace(url);
				}else{
					alert("Error: "+xhr.status+": "+xhr.statusText);
				}
			}
		});
	});
}

function createModalBox(title, text) {
	var content = "<div class='centerAlignOverlap'><div id='overlap' class='clearFix dropShadowBig Colour-White'><div class='closeOverlap'><img src='_images/_button/close.png' alt='Close' class='close' title='Close' /></div><div class='spanFull text-Gray'><h2>"+ title +"</h2></div><div class='spanFull'><h5>"+ text +"</h5></div><div><button class='confirmBtn' type='button'>Confirm</button><button class='cancelBtn' type='button'>Cancel</button></div></div></div>";
	$("#loadPage").html(content);
	$("#loadPage").fadeIn();
}

//REFRESH CHATLIST CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function chatList(){
	var autoLoad = setInterval(
	function (){
	  $('#chatList').load('_include/inc.chatList.php');
	}, 5000); // refresh page every 5 seconds
}

//DATEPICKER CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function yearDropList(currentYear, searchYear){
	if (searchYear == ""){
		searchYear = currentYear;
	}
	var select = document.getElementById('year'),
    year = new Date().getFullYear(),
    html = '<option value="'+searchYear+'">'+searchYear+'</option>';
	for(i = year; i >= year-150; i--) {
		if (i != currentYear){
			html += '<option value="' + i + '">' + i + '</option>';
		}
	}
	select.innerHTML = html;
}

function dateSelect(){
	$('.datepicker').datepicker({
		inline: true,
//		changeMonth: true,
//		changeYear: true,
		//nextText: '&rarr;',
		//prevText: '&larr;',
		showOtherMonths: true,
		yearRange: "-100:+0",
		dateFormat: 'yy-mm-dd',
		dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
		//showOn: "button",
		//buttonImage: "img/calendar-blue.png",
		//buttonImageOnly: true,
	});
}

//EFFECTS CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function hideAllDropDown(){
	$('#contentWrapper').click(function() {
		$(".hideItem").fadeOut('fast');
	});
}

function hideNoticeBar(){
	$(".noticeBar").delay(10000).fadeOut('slow');
}

function dropDownFillSingleValue(elementId, valueFiller){
	$('#'+elementId).val(valueFiller);
}

function addOneSlideToggleTag(tagId,slideVal,slideTag){
	var stateId = $("#"+tagId).val();
	if (stateId == slideVal){
		slideDownTag(slideTag);
	}else{
		slideUpTag(slideTag);
	}
}

function slideDownTag(slide){
	$("#"+slide).slideDown("slow");
}

function slideUpTag(slide){
	$("#"+slide).slideUp("slow");
}

function dropDownFillDoubleValue(elementId, elementId1, selectTagId, selectedTagName){
	window.selectId = $("#"+selectTagId).val();
	var id = $("#"+selectedTagName+selectId).attr('data-id');
	var rel = $("#"+selectedTagName+selectId).attr('data-rel');
	$('#'+elementId).val(rel);
	$('#'+elementId1).val(id);
}

function countChar(val, maxLimit) {
	var len = val.value.length;
	if (len >= maxLimit) {
		val.value = val.value.substring(0, maxLimit);
	} else {
		$('#charNum').text(maxLimit - len);
	}
};

function changeSlideToggleTag(fadeEleCls, slideTagId) {
	var slideId = $("#"+slideTagId).val();
	//alert(slideId);
	$('.'+fadeEleCls).addClass("hidden");
	$(".slideEle"+slideId).removeClass("hidden");
	slideDownTag(".slideEle"+slideId);
};

//AUTOCOMPLETE CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function autoCompleteValidate(searchId, autoTags){
	var searchString = $('#'+searchId).val();
	var found = $.inArray(searchString, autoTags) > -1;
	if(!found){
		$('#'+searchId).val('');
	}
}


//UPLOAD FILE BASIC CS CONTROLLER SCRIPT----------------------------------------------------------------

function uploadFileBasic(){
    'use strict';
    // Change this to the location of your server-side upload handler:
    var url = window.location.hostname === 'blueimp.github.io' ?
                '//jquery-file-upload.appspot.com/' : '_media/_php/';
    $('#fileupload').fileupload({
        url: url,
        dataType: 'json',
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $('<p/>').text(file.name).appendTo('#files');
				$('input#image').val(file.name);
            });
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css(
                'width',
                progress + '%'
            );
        }
    }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');
};

//UPLOAD FILE BASIC PLUS CS CONTROLLER SCRIPT----------------------------------------------------------------

function uploadFileBasicPlus(){
    'use strict';
    // Change this to the location of your server-side upload handler:
    var url = window.location.hostname === 'blueimp.github.io' ?
                '//localhost/stockdesk/' : '_media/_php/',
        uploadButton = $('<button/>')
            .addClass('btn btn-primary')
            .prop('disabled', true)
            .text('Processing...')
            .on('click', function () {
                var $this = $(this),
                    data = $this.data();
                $this
                    .off('click')
                    .text('Abort')
                    .on('click', function () {
                        $this.remove();
                        data.abort();
                    });
                data.submit().always(function () {
                    $this.remove();
                });
            });
    $('#fileupload').fileupload({
        url: url,
        dataType: 'json',
        autoUpload: false,
        acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
        maxFileSize: 5000000, // 5 MB
        // Enable image resizing, except for Android and Opera,
        // which actually support image resizing, but fail to
        // send Blob objects via XHR requests:
        disableImageResize: /Android(?!.*Chrome)|Opera/
            .test(window.navigator.userAgent),
        previewMaxWidth: 100,
        previewMaxHeight: 100,
        previewCrop: true
    }).on('fileuploadadd', function (e, data) {
        data.context = $('<div/>').appendTo('#files');
        $.each(data.files, function (index, file) {
            var node = $('<p/>')
                    .append($('<span/>').text(file.name));
            if (!index) {
                node
                    .append('<br>')
                    .append(uploadButton.clone(true).data(data));
            }
			$('input#image').val(file.name);
            node.appendTo(data.context);
        });
    }).on('fileuploadprocessalways', function (e, data) {
        var index = data.index,
            file = data.files[index],
            node = $(data.context.children()[index]);
        if (file.preview) {
            node
                .prepend('<br>')
                .prepend(file.preview);
        }
        if (file.error) {
            node
                .append('<br>')
                .append(file.error);
        }
        if (index + 1 === data.files.length) {
            data.context.find('button')
                .text('Upload')
                .prop('disabled', !!data.files.error);
        }
    }).on('fileuploadprogressall', function (e, data) {
        var progress = parseInt(data.loaded / data.total * 100, 10);
        $('#progress .progress-bar').css(
            'width',
            progress + '%'
        );
    }).on('fileuploaddone', function (e, data) {
        $.each(data.result.files, function (index, file) {
            var link = $('<a>')
                .attr('target', '_blank')
                .prop('href', file.url);
            $(data.context.children()[index])
                .wrap(link);
        });
    }).on('fileuploadfail', function (e, data) {
        $.each(data.result.files, function (index, file) {
            var error = $('<span/>').text(file.error);
            $(data.context.children()[index])
                .append('<br>')
                .append(error);
        });
    }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');
};

//AUTOCOMPLETE CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function autoCompleteSelect(autoTags){
	$(".tags").autocomplete({
		source: autoTags,
		select: function (event, ui) {
			$('#addFieldBtn').fadeIn();
		}
	});
}

//AUTOCOMPLETE COMBO-BOX CS CONTROLLER SCRIPT------------------------------------------------------------------------------------

function autoCompleteComboBox(){
	(function( $ ) {
		$.widget( "custom.combobox", {
		_create: function() {
		this.wrapper = $( "<span>" )
		.addClass( "custom-combobox" )
		.insertAfter( this.element );
		this.element.hide();
		this._createAutocomplete();
		this._createShowAllButton();
		},
		_createAutocomplete: function() {
		var selected = this.element.children( ":selected" ),
		value = selected.val() ? selected.text() : "";
		this.input = $( "<input>" )
		.appendTo( this.wrapper )
		.val( value )
		.attr( "title", "" )
		.addClass( "custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left" )
		.autocomplete({
		delay: 0,
		minLength: 0,
		source: $.proxy( this, "_source" )
		})
		.tooltip({
		tooltipClass: "ui-state-highlight"
		});
		this._on( this.input, {
		autocompleteselect: function( event, ui ) {
		ui.item.option.selected = true;
		this._trigger( "select", event, {
		item: ui.item.option
		});
		},
		autocompletechange: "_removeIfInvalid"
		});
		},
		_createShowAllButton: function() {
		var input = this.input,
		wasOpen = false;
		$( "<a>" )
		.attr( "tabIndex", -1 )
		.attr( "title", "Show All Items" )
		.tooltip()
		.appendTo( this.wrapper )
		.button({
		icons: {
		primary: "ui-icon-triangle-1-s"
		},
		text: false
		})
		.removeClass( "ui-corner-all" )
		.addClass( "custom-combobox-toggle ui-corner-right" )
		.mousedown(function() {
		wasOpen = input.autocomplete( "widget" ).is( ":visible" );
		})
		.click(function() {
		input.focus();
		// Close if already visible
		if ( wasOpen ) {
		return;
		}
		// Pass empty string as value to search for, displaying all results
		input.autocomplete( "search", "" );
		});
		},
		_source: function( request, response ) {
		var matcher = new RegExp( $.ui.autocomplete.escapeRegex(request.term), "i" );
		response( this.element.children( "option" ).map(function() {
		var text = $( this ).text();
		if ( this.value && ( !request.term || matcher.test(text) ) )
		return {
		label: text,
		value: text,
		option: this
		};
		}) );
		},
		_removeIfInvalid: function( event, ui ) {
		// Selected an item, nothing to do
		if ( ui.item ) {
		return;
		}
		// Search for a match (case-insensitive)
		var value = this.input.val(),
		valueLowerCase = value.toLowerCase(),
		valid = false;
		this.element.children( "option" ).each(function() {
		if ( $( this ).text().toLowerCase() === valueLowerCase ) {
		this.selected = valid = true;
		return false;
		}
		});
		// Found a match, nothing to do
		if ( valid ) {
		return;
		}
		// Remove invalid value
		this.input
		.val( "" )
		.attr( "title", value + " didn't match any item" )
		//.tooltip( "open" );
		this.element.val( "" );
		this._delay(function() {
		this.input.tooltip( "close" ).attr( "title", "" );
		}, 2500 );
		this.input.data( "ui-autocomplete" ).term = "";
		},
		_destroy: function() {
		this.wrapper.remove();
		this.element.show();
		}
		});
	})( jQuery );		
};