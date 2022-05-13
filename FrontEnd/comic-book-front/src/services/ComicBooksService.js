import api from "../api/posts"

export const getComicBooks = async (page, sortOrder, filterPublisher, filterGenre) => {
    let data = [];
    await api.get(`/ComicBooks?page=${page}&Order=${sortOrder.value}&Publisher=${filterPublisher}&Genre=${filterGenre}`)
        .then((result) => { data = result.data })
        .catch((err)=>{});
    return data;
}

export const getComicBook = async (id) => {
    let data = {
        id: 0,
        title: '',
        cover: '',
        genre: '',
        publisher: '',
        issueNumber: 0
    }
    await api.get(`/ComicBooks/${id}`).then((result) => { data = result.data }).catch((err)=>{});
    return data;
}

export const getGenres = async () => {
    let data = [];
    await api.get(`/ComicBooks/Genres`).then((result) => { data = result.data })
    .catch((err)=>{});
    return data;
}

export const getPublishers = async () => {
    let data = [];
    await api.get(`/ComicBooks/Publishers`).then((result) => { data = result.data })
    .catch((err)=>{});
    return data;
}

export const getSearchComics = async (searchString) => {
    let data;
    await api.get(`/ComicBooks/Search?SearchString=${searchString}`)
        .then(result => {
            if (result.status === 200) {
                data = result.data
            }
            else
                if (result.status === 204) {
                    data = []
                }
        }
        ).catch((err) => data = [])
    return data
}