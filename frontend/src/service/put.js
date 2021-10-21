import api from "./api";

export default {
    putCurso(id) {
        return api.UpdateCurso(`/api/Curso/${id}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    putAula(idCurso, tituloDaAula){
        return api.UpdateAulasByCursoID(`/api/Curso/AulaDoCurso?curso=${idCurso}&tituloAula=${tituloDaAula}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}