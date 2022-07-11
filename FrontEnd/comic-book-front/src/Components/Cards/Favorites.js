import FavoriteIcon from '@mui/icons-material/Favorite';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';
import { set } from 'date-fns';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import { addFavorite, deleteFavorite, getFavorite } from '../../services/FavoriteService';
const FavoritesComponent = () => {

    const [fav, setFav] = useState(false)
    let { id } = useParams()
    const navigate = useNavigate()

    const getFav = async () => {
        var result = await getFavorite(id)
        if (result.statusCode == 200) {
            setFav(true)
        }
        else if (result.statusCode == 204) {
            setFav(false)
        }
        else {
            localStorage.clear()
            navigate('/LogIn')
        }
    }

    const removeFav = async () => {
        var result = await deleteFavorite(id)
        if (result.statusCode == 200) {
            setFav(false)
        }
        else if (result.statusCode == 204) {
            setFav(true)
        }
        else {
            localStorage.clear()
            navigate('/LogIn')
        }
    }

    const addFav = async () => {
        var result = await addFavorite(id)
        if (result.statusCode == 200) {
            setFav(true)
        }
        else if (result.statusCode == 204) {
            setFav(false)
        }
        else {
            localStorage.clear()
            navigate('/LogIn')
        }
    }

    useEffect(() => { getFav() }, [fav])
    return (
        <>
            {
                fav === true ?
                    <FavoriteIcon onClick={removeFav}></FavoriteIcon> :
                    <FavoriteBorderIcon onClick={addFav}></FavoriteBorderIcon>
            }
        </>
    )
}
export default FavoritesComponent; 