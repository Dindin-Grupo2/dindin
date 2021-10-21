import api from "./api";

export default {
    putCurso(id) {
        return api.UpdateCurso(`/api/Curso/${id}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    putAula(tituloDoCurso, tituloDaAula){
        return api.UpdateAulasByCursoID(`/api/Curso/AulaDoCurso?titulo=${tituloDoCurso}&tituloAula=${tituloDaAula}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}