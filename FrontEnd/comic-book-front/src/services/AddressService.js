import api from "../api/posts"

export const getCounties = async () => {
    let data = []
    await api.get(`https://roloca.coldfuse.io/judete`).then((result) => {
            data = result.data
        })
        .catch((err) => {
        })
    return data
}
export const getCities = async (county) => {
    let data = []
    await api.get(`https://roloca.coldfuse.io/orase${county}`).then((result) => {
            data = result.data
        })
        .catch((err) => {
        })
    return data
}