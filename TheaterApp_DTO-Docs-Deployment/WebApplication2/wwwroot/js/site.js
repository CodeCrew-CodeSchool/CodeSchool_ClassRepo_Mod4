// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Register() {
	$.post({
		url: '/Users/Register',
		data: { Email: document.getElementById('Email').value, Password: document.getElementById('Password').value, PhoneNumber: document.getElementById('PhoneNumber').value, Username: document.getElementById('Username').value },
		success: function (data) {
			console.log(data);
		},
		datatype: JSON
	});
}