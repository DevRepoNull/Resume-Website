$("#image").change(function () {

    const imageFile = $('input#image')[0].files[0];

    if (imageFile.name.split('.').pop() === "png" || imageFile.name.split('.').pop() === "jpeg" || imageFile.name.split('.').pop() === "jpg") {

        const fd = new FormData();
        fd.append("file", imageFile);

        $.ajax({
            type: "Post",
            url: "/Admin/CustomerFeedback/UploadCustomerFeedbackImageAjax",
            enctype: "multipart/form-data",
            data: fd,
            beforeSend: function () {
                ShowMessage("اعلان", "لطفا تا انتهای بارگذاری صبر کنید ...", "info");
            },
            success: function (response) {
                if (response.status === "Success") {
                    ShowMessage("اعلان", "فایل مورد نظر با موفقیت بارگذاری شد .", "success");
                    $("#Avatar").val(response.imageName);
                }
                else if (response.status === "Error") {
                    ShowMessage("خطا", "فرمت فایل باید jpeg ، jpeg یا png باشد", "error");
                }
            },
            error: function () {
                ShowMessage("خطا", "در بارگذاری فایل خطایی رخ داده است .", "error");
            },
            cache: false,
            contentType: false,
            processData: false
        })
    }
    else {
        ShowMessage("خطا", "فرمت فایل باید jpeg ، jpeg یا png باشد", "error");
    }


});