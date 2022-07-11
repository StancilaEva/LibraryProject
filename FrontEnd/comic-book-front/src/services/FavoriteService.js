import api from "../api/posts"

// export const getAllComicBookReviews = async (comicId) =>{
//     let data = []
//     await api.get(`/Reviews/${comicId}`).then((result) => { data = result.data }).catch((err)=>{});
//     return data
// }
export const getFavorite = async (comicId) =>{
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let data = {
        statusCode:0,
        result:{}
    }
    await api.get(`/Favorites/${comicId}`,header).then((result) => {
        data.statusCode = result.status
        data.result = result.data
    }).catch((err)=>{})
    return data
}

export const getClientFavorites = async (page) =>{
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let data = {
        statusCode:0,
        result:{}
    }
    await api.get(`/Favorites/?page=${page}`,header) 
    .then((result) => {
        data.statusCode = result.status
        data.result = result.data
     }).catch((err)=>{});
    return data
}

export const deleteFavorite = async(comicId)=>{
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let data = {
        statusCode:0,
        result:{}
    }
    await api.delete(`/Favorites/${comicId}`,header).then((result) => {
        data.statusCode = result.status
        data.result = result.data
    }).catch((err)=>{})
    return data
}

export const addFavorite = async (comicId) =>{
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let data = {
        statusCode:0,
        result:{}
    }
    await api.post(`/Favorites/${comicId}`,{},header).then((result) => {
        data.statusCode = result.status
        data.result = result.data
    }).catch((err)=>{})
    return data
}