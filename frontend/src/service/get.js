import api from "./api";

export default {
    getCursos() {
        return api.get('/api/Curso').then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    getCursoID(IdCurso) {
        return api.get(`/api/Curso/${IdCurso}`).then(res => {
            return res
        }).catch(error => {
            return error
        })
    },
    getAulas(IdCurso) {
        return api.get(`/api/Curso/AulasDoCurso/${IdCurso}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}
