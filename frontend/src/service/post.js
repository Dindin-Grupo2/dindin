import api from "./api";

export default {
    postCurso() {
        return api.post(`/api/Curso/`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    postAulas(tituloDoCurso){
        return api.post(`/api/Curso/AulaDoCurso?titulo=${tituloDoCurso}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}
