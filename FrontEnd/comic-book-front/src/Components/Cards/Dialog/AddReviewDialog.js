import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import { Button,Box } from '@mui/material';
import { useState } from 'react';
import TextareaAutosize from '@mui/material/TextareaAutosize';
import Rating from '@mui/material/Rating';
import { addReview } from '../../../services/ReviewService';
import { useNavigate } from 'react-router';


const AddReviewDialog = (props) => {
    const {comicId,setValue,setRefresh,refresh} = props
    const [rating, setRating] = useState(3)
    const [ratingText,setRatingText] = useState("")
    const navigate = useNavigate()



    const handleAddReview = async () => {
        const body = {
            rating:rating,
            reviewText:ratingText
        }
        const result = await addReview(body,comicId)
        if(result.status==200){
            setValue('3')
            setRating(3)
            setRatingText("")
            setRefresh(refresh+1)
        }
        else{
            localStorage.clear()
            navigate('/LogIn')
        }
    }
    return (
        <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
                <Rating
                    name="Rating"
                    value={rating}
                    onChange={(event, newValue) => {
                        setRating(newValue);
                    }}
                    size="large"
                    sx={{margin:'8px'}}
                />
                <TextareaAutosize
                    minRows={3}
                    value={ratingText}
                    onChange={(event) => setRatingText(event.target.value) }
                    placeholder="Write Your Review"
                    style={{margin:'16px',height:'25vh',width:'50vh'}}
                />
                <Button variant="contained" onClick={handleAddReview} style={{margin:'8px'}}>Save</Button>
            
        </Box>
    )
}
export default AddReviewDialog;