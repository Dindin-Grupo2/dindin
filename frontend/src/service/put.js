import api from "./api";

export default {
    putCurso(id) {
        return api.put(`/api/Curso/${id}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    putAula(idCurso, tituloDaAula){
        return api.put(`/api/Curso/AulaDoCurso?curso=${idCurso}&tituloAula=${tituloDaAula}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}
