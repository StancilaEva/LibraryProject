import { RepeatOneSharp } from "@mui/icons-material";
import api from "../api/posts"

export const getAllClientLends = async () => {
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let data = [];
    await api.get(`/Lends`,header).then((result) => 
    {
        if(result.status===200)data = result.data
    }
        ).catch((err) => { })
    return data
}

export const getLendById = async (id) => {
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
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
    await api.get(`/Lends/${id}`,header)
        .then((result) => data = result.data).catch((err) => { });
    return data;
}

export const newLend = async (dates, comicId) => {
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }

    const jsonMessage = {
        status: 0,
        message: ""
    }

    await api.post(`/Lends/BorrowComic/${comicId}`, dates,header)
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
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    const jsonMessage = {
        status: 0,
        message: "",
        lend: {}
    }

    await api.patch(`/Lends/${id}`, { newEndDate },header)
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

export const getTimePeriods = async (id) => {
    let data = [];
    await api.get(`/Lends/Comic/${id}`).then((result) => data = result.data).catch((err) => { })
    return data
}