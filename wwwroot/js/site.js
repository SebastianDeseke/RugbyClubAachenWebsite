// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
  $(".dropdown-item").click(function () {
    var language = $(this).attr("id");

    $.ajax({
      url: "/Language?language=" + language,
      type: "GET",
      data: { Language: language },
      success: function (response) {
        console.log(response);
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});

// File upload validation images
function validateImage() {
  const file = this.files[0];
  const fileType = file["type"];
  const validImageTypes = ["image/gif", "image/jpeg", "image/png"];
  if (!validImageTypes.includes(fileType)) {
    // invalid file type code goes here.
    alert("invalid file type");
  }
}

// File upload validation forms (pdf)
function validateFile() {
  const file = this.files[0];
  const fileType = file["type"];
  const validFileTypes = ["application/pdf"];
  if (!validFileTypes.includes(fileType)) {
    // invalid file type code goes here.
    alert("invalid file type");
  }
}

//Sticky sponsor footer (Chat GPT)
function stickySponsor() {
  var sponsorSection = $(".sponsors");
  var footer = $(".footer");
  var footerOffset = footer.offset().top;

  $(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() > footerOffset) {
      sponsorSection.css({
        position: "absolute",
        bottom: "20px",
        width: "100%",
      });
    } else {
      sponsorSection.css({
        position: "fixed",
        bottom: "0",
        width: "100%",
      });
    }
  });
}
