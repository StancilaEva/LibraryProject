import { useEffect, useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { Button, Card, CardMedia, CssBaseline, Typography } from "@mui/material";
import { Grid } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { useParams } from "react-router-dom";
import { getLendById } from "../../services/LendService";
import ExtendLend from "../Cards/ExtendLendCopmponent";
import { Divider } from "@mui/material";
import {useContext} from "react"
import { UserContext } from "../../Context/userContext";
import LendTimesDialog from "../Cards/Dialog/LendTimesDialog";
import { useNavigate } from "react-router";

function LendPage() {
    const { id } = useParams()
  
    const [lend, setLend] = useState({
        lendId: 0,
        comicBookId: 0,
        comicBookTitle: '',
        comicBookCover: '',
        clientId: 0,
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        extended: false
    })
    const [updated,setUpdated] = useState(false)
    const navigate = useNavigate()

    const LoadLend = async () => {
        const response = await getLendById(id)
        if(response.status===401){
            localStorage.clear()
            navigate('/LogIn')
        } else {
        setLend(response.lend)
        }
    }

    useEffect(() => { LoadLend() }, [updated])

    const parseDate = () =>{
        let startDate  = new Date(lend.startDate)
        let endDate  = new Date(lend.endDate)
        return( `${startDate.getDate()}/${startDate.getMonth()+1}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()+1}/${endDate.getFullYear()}`)
      }
  
    function renderExtension() {
        if (lend.extended == true) {
            return (<Typography>Only one extension per lend</Typography>)
        }
        else {
            return (<ExtendLend id={id} setUpdated={setUpdated}/>)
        }
    }

    return (
        <>
            <ApplicationMenuBar />
            <main>
                <Grid container margin={'1%'} width="99%">
                    <Grid item xs={12} md={6}>
                        <Card sx={{ objectFit: 'contain', height: '85vh' }} >
                            <CardMedia
                                component="img"
                                src={lend.comicBookCover}
                                sx={{ objectFit: 'contain', height: '65vh' }} />
                                 <Divider sx={{margin:'4px'}}/>
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