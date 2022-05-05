import { useEffect,useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { Button, Card, CardMedia, CssBaseline, Typography } from "@mui/material";
import { Grid } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { useParams } from "react-router-dom";
function LendPage()
{
    const {id} = useParams()
    const [newEndDate,setExtendedDate] = useState(new Date(Date.now()))
    const [lendHasBeenExtended,setLendHasBeenExtended] = useState(false)

    const [lend,setLend] = useState({
        lendId:0,
        comicBookId:0,
        comicBookTitle:'',
        comicBookCover:'',
        clientId:0,
        email:'',
        startDate:new Date(Date.now()),
        endDate:new Date(Date.now()),
        extended:false
    })

    const LoadLend = async () =>{
        const response = await fetch(`https://localhost:7015/api/Lends/${id}`)
        if(response.status === 200){
             const result = await response.json()
             setLend(result);
        }
        else{
            alert(response.status)
        }
    }

    useEffect(()=>{LoadLend()},[lendHasBeenExtended])

    const onExtendLendClick = async () =>{
        const response = await fetch(`https://localhost:7015/api/Lends/${lend.lendId}`,{
            mode: 'cors',
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                newEndDate
            })
        })
        if(response.status === 200){
            alert("a mers")
            setLendHasBeenExtended(true)
        }
        else{
            alert("nu a mers")
        }
    }


    const parseDate = () =>{
        let startDate = new Date(lend.startDate)
        let endDate  = new Date(lend.endDate)
        return( `${startDate.getDate()}/${startDate.getMonth()}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()}/${endDate.getFullYear()}`)
      }
    

    function renderExtension(){
        if(lend.extended==true){
            return (<Typography>Only one extension per lend</Typography>)
        }
        else{
            return (
                <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
                            <LocalizationProvider dateAdapter={AdapterDateFns}  >
                                <DatePicker
                                    label="Extend Date"
                                    value={newEndDate}
                                    onChange={(evt) => {
                                        setExtendedDate(evt);
                                    }}
                                    renderInput={(params) => <TextField {...params} />}
                                />
                            </LocalizationProvider>
                            <Button
                            onClick={() => { onExtendLendClick() }}>
                            Extend
                        </Button>
                        </Box>)
        }
    }

    return(
        <>
        <ApplicationMenuBar />
        <main>
            <Grid container margin={'1%'} width="99%">
                <Grid item xs={12} md={6}>
                    <Card sx={{objectFit:'contain', height:'85vh'}} >
                        <CardMedia
                            component="img"
                            image={require(`../../${lend.comicBookCover}`)}
                            sx={{ objectFit: 'contain',height: '65vh' }} />
                        <CardContent>
                            <Container>
                                <Box sx={{ display: 'flex' }}>
                                    <Typography gutterBottom variant="h5" component="div" flex='75%'>
                                        {lend.comicBookTitle}
                                    </Typography>
                                </Box>
                                <Typography gutterBottom variant="h6" component="div" color="text.secondary">
                                    {parseDate()}
                                </Typography>
                            </Container>
                        </CardContent>
                    </Card>
                </Grid>
                <Grid item xs={12} md={6} sx={{ display: "flex", justifyContent: "center", alignItems: "center" }} >
                    {renderExtension()}
                </Grid>
            </Grid>
        </main>
    </>
    )
}
export default LendPage;