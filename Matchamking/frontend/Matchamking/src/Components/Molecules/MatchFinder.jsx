import React from 'react'
import styled from 'styled-components'
import StyledBox from '../Atoms/BoxStyle'

const DatePick = styled.input`
    all: unset;
    margin-right: 1rem;
`
const StyledSearchBox = styled(StyledBox)`
    margin-top: 1rem;
    justify-content: space-between;
`
const BoxText = styled.div`
    margin-left: 1rem;
    color: gray;
`


const MatchFinder = () => {
  return (
    <>
        <StyledSearchBox>
            <BoxText> Filtrar</BoxText>
            <DatePick type='date'/>
        </StyledSearchBox>
    </>
  )
}

export default MatchFinder