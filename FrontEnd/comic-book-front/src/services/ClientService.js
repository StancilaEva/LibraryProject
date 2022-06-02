import api from "../api/posts"

export const getAddress = async () => {
    const header = {
        headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
        }
    }
    let jsonMessage =
    {
        status: 0,
        address: {
            county: '',
            city: '',
            street: '',
            number: 0
        }
    }
    await api.get(`/Client/Address`, header)
        .then((result) => {
            jsonMessage.address = result.data;
            jsonMessage.status = result.status;
        }).catch((err) => { 
            jsonMessage.status = err.response.status
        })
    return jsonMessage
}

export const modifyAddress = async (county, city, street, number) => {
    const header = {
        headers: {
            Authorization: "Bearer " + localStorage.getItem('token')
        }
    }
    let jsonMessage = {
        status: 0,
        message: '',
        address: {}
    };
    await api.patch(`/Client/Address`,
        {
            county,
            city,
            street,
            number
        }, header).then((result) => {
            jsonMessage.status = result.status
            jsonMessage.message = "Address changed"
            jsonMessage.address = result.data
        })
        .catch((err) => {
            jsonMessage.status = err.response.status
            jsonMessage.message = err.response.data.errorMessage
        })
    return jsonMessage
}