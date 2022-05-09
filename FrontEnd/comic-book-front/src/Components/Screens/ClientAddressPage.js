import { useParams } from "react-router-dom";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useEffect, useState } from "react";
import TextField from '@mui/material/TextField';
import { Box, flexbox } from "@mui/system";
import { Button, CssBaseline } from "@mui/material";
import api from "../../api/posts"
import { modifyAddress } from "../../services/ClientService";

function ClientAddress() {
    let { id } = useParams()

    const [county, setCounty] = useState('')
    const [city, setCity] = useState('')
    const [street, setStreet] = useState('')
    const [number, setNumber] = useState(0)


    const loadAddress = async () => {
        const response = await fetch(`https://localhost:7015/api/Client/${id}/Address`)
        if (response.status == 200) {
            var address = await response.json()
            setCounty(address.county)
            setCity(address.city)
            setStreet(address.street)
            setNumber(address.number)
        }
        else {
            alert(response.status)
        }
    }

    const changeAddress = async () => {
        const data = await modifyAddress(id, county, city, street, number)
        setCity(data.city)
        setCounty(data.county)
        setStreet(data.street)
        setNumber(data.number)
    }

    useEffect(() => { loadAddress() }, [])


    return (
        <div>
            <ApplicationMenuBar></ApplicationMenuBar>
            <Box component="form" sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", height: '75vh' }} >
                <TextField
                    required
                    value={county}
                    sx={{ width: 200, marginBottom: 1 }}
                    onChange={evt => setCounty(evt.target.value)}>
                </TextField>
                <TextField
                    required
                    value={city}
                    sx={{ width: 200, marginBottom: 1 }}
                    onChange={evt => setCity(evt.target.value)}>
                </TextField>
                <TextField
                    required
                    sx={{ width: 200, marginBottom: 1 }}
                    value={street}
                    onChange={evt => setStreet(evt.target.value)}>
                </TextField>
                <TextField
                    required
                    sx={{ width: 200, marginBottom: 1 }}
                    value={number}
                    type="number"
                    inputProps={{ min: 0, inputMode: 'numeric', pattern: '[0-9]*' }}
                    onChange={event => setNumber(event.target.value)}>
                </TextField>
                <Button variant="outlined" onClick={changeAddress} sx={{ marginBottom: 1 }}>
                    Change Address
                </Button>
            </Box>
        </div>)
}
export default ClientAddress;