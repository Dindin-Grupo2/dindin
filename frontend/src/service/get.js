import api from "./api";

export default {
    getCursos() {
        return api.GetCursos('/api/Curso').then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    getCursoID(IdCurso) {
        return api.GetCursoID(`/api/Curso/${IdCurso}`).then(res => {
            return res
        }).catch(error => {
            return error
        })
    },
    getAulas(IdCurso) {
        return api.GetAulasByCursoID(`/api/Curso/AulasDoCurso/${IdCurso}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}