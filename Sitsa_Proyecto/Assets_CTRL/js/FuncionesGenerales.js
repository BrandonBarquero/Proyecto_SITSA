function ModalSobreModal() {
    $('.modal').on("hidden.bs.modal", function (e) {
        if ($('.modal:visible').length) {
            $('body').addClass('modal-open');
        }
    });
}

function NoEnterConExepcion() {
    $(document).keypress(function (e) {
        if (e.keyCode === 13 && !e.target.className.includes("PostbackEnter")) {
            e.preventDefault();
            return false;
        }
    });
}

function FuncionesGenerales() {
    ModalSobreModal();
    NoEnterConExepcion();
}

function EnterBuscar(e,index = 0) {
  if (e.keyCode === 13) {
    debugger
        var control = $(".BotonBuscar")[index];
        control.click();
    }
}


function EnterBuscarPorNombre(e, nameButton) {

  if (e.keyCode === 13) {
    debugger
    var control = $("[name='" + nameButton + "']")[0];
    control.click();
  }
}