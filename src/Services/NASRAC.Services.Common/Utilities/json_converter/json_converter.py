import json
import re
from pathlib import Path


def convert_drivers():
    with open(Path('Files/drivers_input.json')) as drivers_json:
        drivers = json.load(drivers_json)

    pkey = 1

    output = []

    for dkey in drivers.keys():
        potential = parse_potential(drivers[dkey]['potential'], drivers[dkey]['age'])

        print(f'Driver: {drivers[dkey]["name"]}, Potential: {potential}')

        driver = {
            'Id': pkey,
            'Name': drivers[dkey]['name'],
            'Age': int(drivers[dkey]['age']),
            'ShortTrackRating': int(drivers[dkey]['short_rating']),
            'IntermediateRating': int(drivers[dkey]['intermediate_rating']),
            'SuperspeedwayRating': int(drivers[dkey]['super_speedway_rating']),
            'RoadTrackRating': int(drivers[dkey]['road_course_rating']),
            'PerformanceRating': 0,
            'PotentialRating': 0,
            'OverallRating': (int(drivers[dkey]['short_rating']) +
                              int(drivers[dkey]['intermediate_rating']) +
                              int(drivers[dkey]['super_speedway_rating']) +
                              int(drivers[dkey]['road_course_rating'])) / 4,
            'ProgressionRate': potential[0],
            'RegressionRate': potential[3],
            'PeakAgeStart': potential[1],
            'PeakAgeEnd': potential[2],
            'RetirementFactor': 0.005,
            'DNFOdds': 0.025,
            'Marketability': 'Average'
        }

        output.append(driver)

    with open(Path('Files/drivers_output.json'), 'w+') as drivers_json:
        json.dump(output, drivers_json, indent=4)


def parse_potential(potential: str, age: str):
    progression_match = re.search(r'^(\d+)p', potential)
    single_rate_match = re.search(r'\((\d+)\)', potential)
    multi_rate_match = re.search(r'(\d+-\d+)', potential)
    regression_match = re.search(r'(\d+)r', potential)

    progression = 0
    peak_age_start = 0
    peak_age_end = 0
    regression = 0

    if progression_match:
        progression = int(progression_match.group(1))

    if single_rate_match:
        peak_age_start = int(age) + int(single_rate_match.group(1)) - 2
        peak_age_end = peak_age_start + 1

    if multi_rate_match:
        year_range = multi_rate_match.group(1).split('-')
        peak_age_start = int(age) + int(year_range[0]) - 2
        peak_age_end = int(age) + int(year_range[1]) - 2

    if regression_match:
        regression = int(regression_match.group(1))

    return progression, peak_age_start, peak_age_end, regression


if __name__ == '__main__':
    convert_drivers()
