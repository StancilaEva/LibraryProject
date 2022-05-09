import api from "../api/posts"

export const getComicBooks = async (page, sortOrder, filterPublisher, filterGenre) => {
    let data;
    await api.get(`/ComicBooks?page=${page}&Order=${sortOrder.value}&Publisher=${filterPublisher}&Genre=${filterGenre}`)
    .then((result)=> {data = result.data});
    return data;
}

export const getComicBook = async (id) => {
    let data;
    await api.get(`/ComicBooks/${id}`).then((result)=>{data=result.data});
    return data;
}

export const getGenres = async () =>{
    let data;
    await api.get(`/ComicBooks/Genres`).then((result)=>{data=result.data});
    return data;
}

export const getPublishers = async ()=>{
    let data;
    await api.get(`/ComicBooks/Publishers`).then((result)=>{data=result.data});
    return data;
}