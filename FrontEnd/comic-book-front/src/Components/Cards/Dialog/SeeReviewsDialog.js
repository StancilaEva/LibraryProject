import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import { Button, Card, CardContent, CardHeader, Typography,Paper,Box } from '@mui/material';
import { useState } from 'react';
import TextareaAutosize from '@mui/material/TextareaAutosize';
import Rating from '@mui/material/Rating';
import { addReview, getAllComicBookReviews } from '../../../services/ReviewService';
import { useEffect } from 'react';
const SeeReviewsDialog = (props) => {
    const { comicId } = props
    const [reviews, setReviews] = useState([])

    const handleClickOpen = async () => {
        const response = await getAllComicBookReviews(comicId)
        setReviews(response)
    };

    

    useEffect(()=>{handleClickOpen()},[])
    return (
        <Box style={{maxHeight: '60vh', overflow: 'auto'}}>
                <List>
                    {reviews.map((review, key) => (
                        <ListItem key={key}>
                            <Card sx={{ width: '60vh' }}>
                                <CardContent>
                                    <Typography gutterBottom component="div" alignItems={'center'}>
                                        {`${review.author.username}:   `}
                                    </Typography>
                                    <Rating name="Rating" value={review.rating} readOnly></Rating>
                                    <Typography
                                        paragraph
                                    >{`${review.reviewText}`}</Typography>
                                </CardContent>
                            </Card>
                        </ListItem>
                    ))}
                </List>
                </Box>

    )
}
export default SeeReviewsDialog;