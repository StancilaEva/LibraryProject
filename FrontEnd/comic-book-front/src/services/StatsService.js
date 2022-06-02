import api from "../api/posts"

export const GetMostBorrowedBooks = async () =>
{
    let data = [];
    await api.get(`/Stats/MostBorrowedComics`).then((result) => data = result.data).catch((err) => { })
    return data
} //GetMostReadGenres()

export const GetMostReadGenres = async () =>
{
    let data = [];
    await api.get(`/Stats/MostReadGenres`).then((result) => data = result.data).catch((err) => { })
    return data
} 

export const GetMostReadPublishers = async () =>
{
    let data = [];
    await api.get(`/Stats/MostReadPublishers`).then((result) => data = result.data).catch((err) => { })
    return data
} 

export const GetUserWithMostComics = async () =>
{
    let data = [];
    await api.get(`/Stats/UserWithMostBorrowedComics`).then((result) => data = result.data).catch((err) => { })
    return data
} 