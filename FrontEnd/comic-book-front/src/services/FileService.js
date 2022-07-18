import api from "../api/posts"

const header = {
    headers: {
       Authorization: "Bearer " + localStorage.getItem('token')
    }
 }

export const uploadFile = async (formFile) =>{
    const data = {
        status:0,
        cover:''
    }
    await api.post('/File/ComicCover',formFile,header)
    .then((result)=>
    {
        data.status = result.status
        data.cover=result.data
    }).catch((err)=>
    {data.status=err.response.status}
    )
    return data
}