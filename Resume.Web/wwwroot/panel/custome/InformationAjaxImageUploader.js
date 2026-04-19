$("#image-uploader").change(function () {

    const imageFile = $('input#image-uploader')[0].files[0];

    if (!imageFile) return;

    const ext = imageFile.name.split('.').pop().toLowerCase();
    if (ext === "png" || ext === "jpeg" || ext === "jpg") {

        const fd = new FormData();
        fd.append("file", imageFile);

        $.ajax({
            type: "POST",
            url: "/Admin/Information/UploadInformationAvatarAjax",
            data: fd,
            beforeSend: function () {
                ShowMessage("اعلان", "لطفا تا انتهای بارگذاری صبر کنید ...", "info");
            },
            success: function (response) {
                if (response.status === "Success") {

                    // مهم‌ترین قسمت تعمیر:
                    // نام عکس برمی‌گردد → در hidden ذخیره می‌کنیم
                    $("#Avatar").val(response.imageName);

                    ShowMessage("اعلان", "فایل با موفقیت بارگذاری شد.", "success");
                }
                else {
                    ShowMessage("خطا", "فرمت فایل باید jpeg یا jpg یا png باشد", "error");
                }
            },
            error: function () {
                ShowMessage("خطا", "در بارگذاری فایل خطا رخ داد.", "error");
            },
            cache: false,
            contentType: false,
            processData: false
        });
    }
    else {
        ShowMessage("خطا", "فرمت فایل باید jpeg یا jpg یا png باشد", "error");
    }

});