import api from "./api";

export default {
    deleteCurso(id) {
        return api.delete(`/api/Curso/${id}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
    deleteAula(idCurso) {
        return api.delete(`/api/Curso/AulaDoCurso/${idCurso}`).then(res => {
            return res

        }).catch(error => {
            return error
        })
    },
}
