import { Box } from "@mui/system";
import { TextField } from "@mui/material";
import React, { useEffect } from "react";
import { getCities, getCounties } from "../../../services/AddressService";
import { useState } from "react";
import { MenuItem } from "@mui/material";
import { Card } from "@mui/material";
import { CardContent } from "@mui/material";


const AddressForm = (props) => {
    const { user, setUser, county, city, street, number, errors } = props;
    const [counties, setCounties] = useState([{ auto: "Empty", nume: "Empty" }])
    const [cities, setCities] = useState([{ auto: "Empty", nume: "Empty" }])
    const [selectedCounty, setSelectedCounty] = useState('Empty')
    const [selectedCity,setSelectedCity] = useState('Empty')

    const loadCountiesData = async () => {
        const countiesData = await getCounties();
        const newCounties = [{ auto: "Empty", nume: "Empty" }].concat(countiesData)
        setCounties(newCounties)
    }

    const loadCitiesData = async () => {
        const getAuto = counties.filter((obj) => { return obj.nume === selectedCounty })
        const countyValue = selectedCounty === 'Empty' ? '' : `/${getAuto[0].auto}`
        const citiesData = await getCities(countyValue);
        const newCities = [{ auto: "Empty", nume: "Empty" }].concat(citiesData)
        setSelectedCity(newCities[0].nume)
        setCities(newCities)
    }

    useEffect(() => { loadCountiesData() }, [])
    useEffect(() => { loadCitiesData() }, [selectedCounty])

    return (
        <Box sx={{ width: '100%', display: 'center', justifyContent: "center", alignItems: "center", marginTop: "5%" }}>
            <Card sx={{ width: '50%', alignSelf: 'center', justifySelf: 'center', height: '60%' }}>
                <CardContent>
                    <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
                        <TextField
                            select
                            {...county}
                            label={"County"}
                            defaultValue={counties[0].auto}
                            onChange={(event) => {
                                setSelectedCounty(event.target.value)
                                setUser({ ...user, county: event.target.value })
                            }}
                            sx={{ margin: "16px", wdith: "20%" }}
                            helperText={errors ? errors.county?.message : null}>
                            {
                                counties.map((option, key) => (
                                    <MenuItem key={key} value={option.nume}>
                                        {option.nume}
                                    </MenuItem>))
                            }
                        </TextField>
                        <TextField
                            select
                            {...city}
                            label={"City"}
                            defaultValue={cities[0].nume}
                            value = {selectedCity}
                            onChange={(event) => {
                                setSelectedCity(event.target.value)
                                setUser({ ...user, city: event.target.value 
                                })}}
                            sx={{ margin: "16px", wdith: "20%" }}
                            helperText={errors ? errors.city?.message : null}>
                            {
                                cities.map((option, key) => (
                                    <MenuItem key={key} value={option.nume}>
                                        {option.nume}
                                    </MenuItem>
                                ))}
                        </TextField>
                        <TextField
                            {...street}
                            placeholder="Street"
                            defaultValue={user.street}
                            sx={{ margin: "16px", wdith: "20%" }}
                            onChange={(event) => setUser({ ...user, street: event.target.value })}
                            helperText={errors ? errors.street?.message : null}
                        />
                        <TextField
                            {...number}
                            placeholder="Number"
                            type="number"
                            inputProps={{ min: 1, inputMode: 'numeric', pattern: '[0-9]*' }}
                            helperText={errors ? errors.number?.message : null}
                            defaultValue={user.number}
                            sx={{ margin: "16px", wdith: "20%" }}
                            onChange={(event) => setUser({ ...user, number: event.target.value })}
                        />
                    </Box>
                </CardContent>
            </Card>
        </Box>

    )
}
export default AddressForm