import api from "./api";

export default {
    postCurso() {
        return api.CreateCurso(`/api/Curso/`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    postAulas(tituloDoCurso){
        return api.CreateAulaByCursoTitulo(`/api/Curso/AulaDoCurso?titulo=${tituloDoCurso}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    }
}