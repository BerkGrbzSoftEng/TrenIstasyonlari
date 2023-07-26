"use strict";
var KTUsersAddUser = function () {
    const t = document.getElementById("kt_modal_add_user"),
        e = t.querySelector("#kt_modal_add_user_form"),
        n = new bootstrap.Modal(t);
    return {
        init: function () {
            (() => {
                var o = FormValidation.formValidation(e, {
                    fields: {
                        IstasyonAdi: {
                            validators: {
                                notEmpty: {
                                    message: "Istasyon Adi Zorunludur"
                                }
                            }
                        },
                        IstasyonKonum: {
                            validators: {
                                notEmpty: {
                                    message: "Istasyon Konumu Zorunludur"
                                }
                            }
                        },
                        IstasyonAdres: {
                            validators: {
                                notEmpty: {
                                    message: "Istasyon Adresi Zorunludur"
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger,
                        bootstrap: new FormValidation.plugins.Bootstrap5({
                            rowSelector: ".fv-row",
                            eleInvalidClass: "",
                            eleValidClass: ""
                        })
                    }
                });
                const i = t.querySelector('[data-kt-users-modal-action="submit"]');
                i.addEventListener("click", (t => {
                    t.preventDefault(), o && o.validate().then((function (t) {
                        console.log("validated!"), "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"), i.disabled = !0,
                            setTimeout((function () {
                                $.ajax({
                                    url: '/Train/AddTrain',
                                    type: 'POST',
                                    dataType: 'json',
                                    cache: false,
                                    data: new FormData(document.getElementById("kt_modal_add_user_form")),
                                    processData: false,
                                    contentType: false, 
                                    
                                });
                                i.removeAttribute("data-kt-indicator"), i.disabled = !1,
                                    Swal.fire({
                                        text: "Istasyon Ekleme Basariyla Gerceklestirildi!",
                                        icon: "success",
                                        buttonsStyling: !1,
                                        confirmButtonText: "Tamam",
                                        customClass: {
                                            confirmButton: "btn btn-primary"
                                        }
                                    }).then((function (t) {
                                        location.reload(true)
                                        t.isConfirmed && n.hide()
                                    }))
                            }), 2e3)) : Swal.fire({
                                text: "Maalesef bazi hatalar algilandi, lutfen tekrar deneyin.",
                                icon: "error",
                                buttonsStyling: !1,
                                confirmButtonText: "Tamam!",
                                customClass: {
                                    confirmButton: "btn btn-primary"
                                }
                            })
                    }))
                })),
                    t.querySelector('[data-kt-users-modal-action="cancel"]').addEventListener("click", (t => {
                        t.preventDefault(), Swal.fire({
                            text: "Iptal etmek istediginizden emin misiniz??",
                            icon: "warning",
                            showCancelButton: !0,
                            buttonsStyling: !1,
                            confirmButtonText: "Evet, iptal et!",
                            cancelButtonText: "Hayir, Forma don",
                            customClass: {
                                confirmButton: "btn btn-primary",
                                cancelButton: "btn btn-active-light"
                            }
                        }).then((function (t) {
                            t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                                text: "Formunuz iptal edilmedi!.",
                                icon: "error",
                                buttonsStyling: !1,
                                confirmButtonText: "Tamam!",
                                customClass: {
                                    confirmButton: "btn btn-primary"
                                }
                            })
                        }))
                    })), t.querySelector('[data-kt-users-modal-action="close"]').addEventListener("click", (t => {
                        t.preventDefault(), Swal.fire({
                            text: "Iptal etmek istediginizden emin misiniz?",
                            icon: "warning",
                            showCancelButton: !0,
                            buttonsStyling: !1,
                            confirmButtonText: "Evet, iptal et!",
                            cancelButtonText: "Hayir, Forma don",
                            customClass: {
                                confirmButton: "btn btn-primary",
                                cancelButton: "btn btn-active-light"
                            }
                        }).then((function (t) {
                            t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                                text: "Formunuz iptal edilmedi!.",
                                icon: "error",
                                buttonsStyling: !1,
                                confirmButtonText: "Tamam!",
                                customClass: {
                                    confirmButton: "btn btn-primary"
                                }
                            })
                        }))
                    }))
            })()
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTUsersAddUser.init()
}));