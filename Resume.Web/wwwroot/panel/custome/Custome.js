//General loading methods
function StartLoading() {
    $("body").waitMe({
        effect: 'bounce',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function CloseLoading() {
    $("body").waitMe('hide');
}

//ThingIDo
function LoadThingIDoFromModal(id) {
    $.ajax({
        url: "/Admin/ThingIDo/LoadThingIDoFromModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#ThingIDoForm').data('validator', null);
            $.validator.unobtrusive.parse("#ThingIDoForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function ThingIDoFromSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteThingIDo(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/ThingIDo/DeleteThingIDo",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Education
function LoadEducationFormModal(id) {
    $.ajax({
        url: "/Admin/Education/LoadEducationFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#EducationForm').data('validator', null);
            $.validator.unobtrusive.parse("#EducationForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function EducationFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteEducation(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/Education/DeleteEducation",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Skill
function LoadSkillFormModal(id) {
    $.ajax({
        url: "/Admin/Skill/LoadSkillFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#SkillForm').data('validator', null);
            $.validator.unobtrusive.parse("#SkillForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function SkillFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteSkill(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/Skill/DeleteSkill",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//CustomerFeedback
function LoadCustomerFeedbackFormModal(id) {
    $.ajax({
        url: "/Admin/CustomerFeedback/LoadCustomerFeedbackFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#CustomerFeedbackForm').data('validator', null);
            $.validator.unobtrusive.parse("#CustomerFeedbackForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function CustomerFeedbackFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteCustomerFeedback(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/CustomerFeedback/DeleteCustomerFeedback",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Experience
function LoadExperienceFormModal(id) {
    $.ajax({
        url: "/Admin/Experience/LoadExperienceFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#ExperienceForm').data('validator', null);
            $.validator.unobtrusive.parse("#ExperienceForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function ExperienceFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteExperience(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/Experience/DeleteExperience",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Portfolio Category
function LoadPortfolioCategoryFormModal(id) {
    $.ajax({
        url: "/Admin/PortfolioCategory/LoadPortfolioCategoryFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#PortfolioCategoryForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioCategoryForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioCategoryFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeletePortfolioCategory(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/PortfolioCategory/DeletePortfolioCategory",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Customer Logo
function LoadCustomerLogoFormModal(id) {
    $.ajax({
        url: "/Admin/CustomerLogo/LoadCustomerLogoFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#CustomerLogoForm').data('validator', null);
            $.validator.unobtrusive.parse("#CustomerLogoForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function CustomerLogoFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteCustomerLogo(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/CustomerLogo/DeleteCustomerLogo",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Portfolio
function LoadPortfolioFormModal(id) {
    $.ajax({
        url: "/Admin/Portfolio/LoadPortfolioFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#PortfolioForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeletePortfolio(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/Portfolio/DeletePortfolio",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Social Media
function LoadSocialMediaFormModal(id) {
    $.ajax({
        url: "/Admin/SocialMedia/LoadSocialMediaFormModal",
        type: "get",
        data: { id: id },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#SocialMediaForm').data('validator', null);
            $.validator.unobtrusive.parse("#SocialMediaForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function SocialMediaFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

function DeleteSocialMedia(id) {

    Swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر"
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/SocialMedia/DeleteSocialMedia",
                type: "get",
                data: { id: id },

                beforeSend: function () {
                    StartLoading();
                },

                success: function (res) {
                    CloseLoading();

                    if (res.status == "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                    }
                },

                error: function () {
                    CloseLoading();
                }
            });

        }

    });
}

//Information
function LoadInformationFormModal() {
    $.ajax({
        url: "/Admin/Information/LoadInformationFormModal",
        type: "get",
        data: { },

        beforeSend: function () {
            StartLoading();
        },

        success: function (res) {
            CloseLoading();

            $("#modal-main-content").html(res);

            $('#InformationForm').data('validator', null);
            $.validator.unobtrusive.parse("#InformationForm");

            var modal = new bootstrap.Modal(document.getElementById('modal-main'));
            modal.show();
        },

        error: function () {
            CloseLoading();
        }
    });
}

function InformationFormSubmited(res) {

    CloseLoading();

    if (res.status == 'Success') {

        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');

        bootstrap.Modal.getInstance(document.getElementById('modal-main')).hide();

        location.reload();

        //$('#data-table-box').load(location.href + ' #data-table-box');
        //$.getScript('/panel/vendor/datatables/js/jquery.dataTables.min.js', function (data, textStatus, jqxhr) { });
        //$.getScript('/panel/js/plugins-init/datatables.init.js', function (data, textStatus, jqxhr) { });

    } else {

        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');

    }
}

//Message
function DeleteMessage(id) {

Swal.fire({
    title: "اخطار",
    text: "آیا از حذف این آیتم اطمینان دارید؟",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "بله",
    cancelButtonText: "خیر"
}).then((result) => {

    if (result.isConfirmed) {

        $.ajax({
            url: "/Admin/Message/DeleteMessage",
            type: "get",
            data: { id: id },

            beforeSend: function () {
                StartLoading();
            },

            success: function (res) {
                CloseLoading();

                if (res.status == "Success") {
                    ShowMessage('عملیات با موفقیت انجام شد', 'پیغام موفقیت', 'success');
                    $(`#ListItem-${id}`).remove();
                } else {
                    ShowMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error');
                }
            },

            error: function () {
                CloseLoading();
            }
        });

    }

});
}