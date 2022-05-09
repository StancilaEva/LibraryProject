import api from "../api/posts"

export const getAddress = async (id) => {
    let data
    await api.get(`/Client/${id}/Address`)
        .then((result) => data = result.data)
    return data
}

export const modifyAddress = async (id, county, city, street, number) => {
    let data;
    await api.patch(`/Client/${id}/Address`,
        {
            county,
            city,
            street,
            number
        }).then((result) => {
            data = result.data
            alert("merge")
        })
        .catch((err) => {
            alert(err.response.data)
        })
    return data
}