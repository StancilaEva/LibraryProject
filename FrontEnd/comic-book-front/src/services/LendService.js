import { RepeatOneSharp } from "@mui/icons-material";
import api from "../api/posts"

export const getAllClientLends = async (id) => {
    let data = [];
    await api.get(`/Client/${id}/Lends`).then((result) => data = result.data).catch((err)=>{})
    return data
}

export const getLendById = async (id) => {
    let data = {
        lendId: 0,
        comicBookId: 0,
        comicBookTitle: '',
        comicBookCover: '',
        clientId: 0,
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        extended: false
    };
    await api.get(`/Lends/${id}`)
        .then((result) => data = result.data).catch((err)=>{});
    return data;
}

export const newLend = async (dates, comicId) => {
    const jsonMessage = {
        status: 0,
        message: ""
    }

    await api.post(`/Lends/1/comicBook/${comicId}`, dates)
        .then((result) => {
            jsonMessage.status = result.status
            jsonMessage.message = "Lend was successful!"
        })
        .catch((err) => {
            jsonMessage.status = err.response.status
            jsonMessage.message = err.response.data.errorMessage
        })

    return jsonMessage
}

export const extendLend = async (id, newEndDate) => {
    const jsonMessage = {
        status: 0,
        message: "",
        lend: {}
    }

    await api.patch(`/Lends/${id}`, { newEndDate })
        .then((result) => {
            jsonMessage.status = result.status
            jsonMessage.message = "End date updated!"
            jsonMessage.lend = result.data
        })
        .catch((err) => {
            jsonMessage.status = err.response.status
            jsonMessage.message = err.response.data.errorMessage
        })

    return jsonMessage
}