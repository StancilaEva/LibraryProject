import api from "../api/posts"

export const addReview = async (review,comicId) => {
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let jsonMessage = {
        status:0,
        data: {
        count:0,
        lends:[]
        }
    }
    
    await api.post(`/Reviews/${comicId}`, review, header)
        .then((result) => {
            jsonMessage.status = result.status
            jsonMessage.message = "Review posted"
        })
        .catch((err) => {
            jsonMessage.status = err.response.status
            jsonMessage.message = err.response.data.errorMessage
        })
    return jsonMessage
}

export const getComicBookReview = async (comicId) =>{
    let data=0;
    await api.get(`/Reviews/Rating/${comicId}`).then((result) => { data = result.data }).catch((err)=>{});
    return data;
}

export const getAllComicBookReviews = async (comicId) =>{
    let data = []
    await api.get(`/Reviews/${comicId}`).then((result) => { data = result.data }).catch((err)=>{});
    return data
}

