//FUNCIONALIDAD DATATABLES PAGINACION
class paginacion {
    constructor(id, valor) {
        this.id = id;
        this.valor = valor;
    }
}
var listaGrids = new Array();

function AsignarPaginacion() {
    $('table').on("page.dt", function (e) {
        let id = e.currentTarget.id;
        let tablaTramites = $('#' + id).DataTable();
        let infoTablaTramites = tablaTramites.page.info();
        let lista = new Array();
        listaGrids.forEach(x => {
            if (x.id != id) {
                lista.push(x);
            }
        });
        listaGrids = lista;
        const obPaginacion = new paginacion(id, infoTablaTramites.page);
        listaGrids.push(obPaginacion);
    });

    let tabla;
    listaGrids.forEach(x => {
        tabla = $('#' + x.id).DataTable();
        tabla.page(x.valor).draw(false);
    });
}

function ReiniciarPaginacion(id) {
    let lista = new Array();
    listaGrids.forEach(x => {
        if (x.id != id) {
            lista.push(x);
        }
    });
    listaGrids = lista;
}