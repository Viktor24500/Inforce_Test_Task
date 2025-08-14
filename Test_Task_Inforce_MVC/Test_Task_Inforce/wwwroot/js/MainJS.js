function EditAbout() {
    debugger;
    let descriptionFromForm = document.getElementById("aboutDescription").value;
    let descriptionFromParagraph=document.getElementById("description").innerText;
    //paragraph.innerHTML = text;
	let Http = new XMLHttpRequest();
	let url = "/about";
	Http.open("PUT", url);
	Http.setRequestHeader("Content-Type", "application/json; charset=utf-8")
	Http.send(
		JSON.stringify(
			{
				oldDescription: descriptionFromParagraph,
				newDescription: descriptionFromForm
				
			},
		)
	);

	Http.onreadystatechange = function () {
		if (Http.readyState === 4 && Http.status === 200) {
			console.log(Http.responseText);
		}
	};
}
//function GetDescription()
//{
//    let text = document.getElementById("description").textContent;
//    document.getElementById("aboutDescription").value = text;
//}
function CloseForm() {
    document.getElementsByClassName("modal")[0].style.display = "none";
}
function OpenForm() {
    document.getElementsByClassName("modal")[0].style.display = "block";
}

function EditDescription()
{
    const text = document.getElementById("description").innerText;

    document.getElementById("aboutDescription").value = text;

    document.getElementsByClassName("modal")[0].style.display = "block";
}