import { RepeatOneSharp } from "@mui/icons-material";
import api from "../api/posts"

export const getAllClientLends = async (page,time) => {
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
    
    await api.get(`/Lends?page=${page}&time=${time===-1?'':time}`,header).then((result) => 
    {
        if(result.status===200){
            jsonMessage.data.lends = result.data.lends
            jsonMessage.data.count = result.data.count
        }
    }
        ).catch((err) => {
            jsonMessage.status = err.response.status
         })
    return jsonMessage
}

export const getLendById = async (id) => {
    const header = {
        headers: {
           Authorization: "Bearer " + localStorage.getItem('token')
        }
     }
    let jsonMessage = {
        status:0,
        lend:{
        lendId: 0,
        comicBookId: 0,
        comicBookTitle: '',
        comicBookCover: '',
        clientId: 0,
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        extended: false}
    };
    await api.get(`/Lends/${id}`,header)
        .then((result) => {
            jsonMessage.lend = result.data
            jsonMessage.status = result.data
        }).catch((err) => { 
            jsonMessage.status = err.response.status
        });
    return jsonMessage;
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