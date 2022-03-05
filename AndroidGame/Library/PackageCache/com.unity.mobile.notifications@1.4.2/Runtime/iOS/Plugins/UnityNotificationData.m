//
//  UnityNotificationData.m
//  iOS.notifications
//

#if TARGET_OS_IOS

#import <Foundation/Foundation.h>
#import <UserNotifications/UserNotifications.h>
#if UNITY_USES_LOCATION
#import <CoreLocation/CoreLocation.h>
#endif

#import "UnityNotificationData.h"

NotificationSettingsData UNNotificationSettingsToNotificationSettingsData(UNNotificationSettings* settings)
{
    NotificationSettingsData settingsData;

    settingsData.alertSetting = (int)settings.alertSetting;
    settingsData.authorizationStatus = (int)settings.authorizationStatus;
    settingsData.badgeSetting = (int)settings.badgeSetting;
    settingsData.carPlaySetting = (int)settings.carPlaySetting;
    settingsData.lockScreenSetting = (int)settings.lockScreenSetting;
    settingsData.notificationCenterSetting = (int)settings.notificationCenterSetting;
    settingsData.soundSetting = (int)settings.soundSetting;
    settingsData.alertStyle = (int)settings.alertStyle;

    if (@available(iOS 11.0, *))
    {
        settingsData.showPreviewsSetting = (int)settings.showPreviewsSetting;
    }
    else
    {
        settingsData.showPreviewsSetting = 2;
    }
    return settingsData;
}

void initiOSNotificationData(iOSNotificationData* notificationData)
{
    notificationData->title = NULL;
    notificationData->body = NULL;
    notificationData->badge = 0;
    notificationData->subtitle = NULL;
    notificationData->categoryIdentifier = NULL;
    notificationData->threadIdentifier = NULL;
    notificationData->triggerType = PUSH_TRIGGER;
    notificationData->userInfo = NULL;
}

void parseCustomizedData(iOSNotificationData* notificationData, UNNotificationRequest* request)
{
    NSDictionary* userInfo = request.content.userInfo;
    NSObject* customizedData = [userInfo objectForKey: @"data"];

    // For local notifications, the customzied data is always a string.
    if (notificationData->triggerType == TIME_TRIGGER || notificationData->triggerType == CALENDAR_TRIGGER || customizedData == nil)
    {
        notificationData->userInfo = (__bridge_retained void*)userInfo;
        return;
    }

    // For push notifications, we have to handle more cases.
    NSString* strData;
    if ([NSJSONSerialization isValidJSONObject: customizedData])
    {
        NSError* error;
        NSData* data = [NSJSONSerialization dataWithJSONObject: customizedData options: NSJSONWritingPrettyPrinted error: &error];
        if (!data)
        {
            NSLog(@"Failed parsing notification userInfo[\"data\"]: %@", error);
            return;
        }

        strData = [[NSString alloc] initWithData: data encoding: NSUTF8StringEncoding];
    }
    else
    {
        // Convert bool defined with true/false in payload to "true"/"false", otherwise it will be converted to 1/0.
        if ([customizedData isKindOfClass: [NSNumber class]] && CFBooleanGetTypeID() == CFGetTypeID((__bridge CFTypeRef)(customizedData)))
        {
            NSNumber* number = (NSNumber*)customizedData;
            strData = number.boolValue ? @"true" : @"false";
        }
        else
        {
            strData = customizedData.description;
        }
    }

    NSMutableDictionary* parsedUserInfo = [NSMutableDictionary dictionaryWithDictionary: userInfo];
    [parsedUserInfo setValue: strData forKey: @"data"];
    notificationData->userInfo = (__bridge_retained void*)parsedUserInfo;
}

iOSNotificationData UNNotificationRequestToiOSNotificationData(UNNotificationRequest* request)
{
    iOSNotificationData notificationData;
    initiOSNotificationData(&notificationData);

    UNNotificationContent* content = request.content;

    notificationData.identifier = strdup([request.identifier UTF8String]);

    if (content.title != nil && content.title.length > 0)
        notificationData.title = strdup([content.title UTF8String]);

    if (content.body != nil && content.body.length > 0)
        notificationData.body = strdup([content.body UTF8String]);

    notificationData.badge = [content.badge intValue];

    if (content.subtitle != nil && content.subtitle.length > 0)
        notificationData.subtitle = strdup([content.subtitle UTF8String]);

    if (content.categoryIdentifier != nil && content.categoryIdentifier.length > 0)
        notificationData.categoryIdentifier = strdup([content.categoryIdentifier UTF8String]);

    if (content.threadIdentifier != nil && content.threadIdentifier.length > 0)
        notificationData.threadIdentifier = strdup([content.threadIdentifier UTF8String]);

    if ([request.trigger isKindOfClass: [UNTimeIntervalNotificationTrigger class]])
    {
        notificationData.triggerType = TIME_TRIGGER;

        UNTimeIntervalNotificationTrigger* timeTrigger = (UNTimeIntervalNotificationTrigger*)request.trigger;
        notificationData.timeTriggerInterval = timeTrigger.timeInterval;
        notificationData.repeats = timeTrigger.repeats;
    }
    else if ([request.trigger isKindOfClass: [UNCalendarNotificationTrigger class]])
    {
        notificationData.triggerType = CALENDAR_TRIGGER;

        UNCalendarNotificationTrigger* calendarTrigger = (UNCalendarNotificationTrigger*)request.trigger;
        NSDateComponents* date = calendarTrigger.dateComponents;

        notificationData.calendarTriggerYear = (int)date.year;
        notificationData.calendarTriggerMonth = (int)date.month;
        notificationData.calendarTriggerDay = (int)date.day;
        notificationData.calendarTriggerHour = (int)date.hour;
        notificationData.calendarTriggerMinute = (int)date.minute;
        notificationData.calendarTriggerSecond = (int)date.second;
    }
    else if ([request.trigger isKindOfClass: [UNLocationNotificationTrigger class]])
    {
#if UNITY_USES_LOCATION
        notificationData.triggerType = LOCATION_TRIGGER;

        UNLocationNotificationTrigger* locationTrigger = (UNLocationNotificationTrigger*)request.trigger;
        CLCircularRegion *region = (CLCircularRegion*)locationTrigger.region;

        notificationData.locationTriggerCenterX = region.center.latitude;
        notificationData.locationTriggerCenterY = region.center.longitude;
        notificationData.locationTriggerRadius = region.radius;
        notificationData.locationTriggerNotifyOnExit = region.notifyOnEntry;
        notificationData.locationTriggerNotifyOnEntry = region.notifyOnExit;
#endif
    }
    else if ([request.trigger isKindOfClass: [UNPushNotificationTrigger class]])
    {
        notificationData.triggerType = PUSH_TRIGGER;
    }

    parseCustomizedData(&notificationData, request);

    return notificationData;
}

void freeiOSNotificationData(iOSNotificationData* notificationData)
{
    if (notificationData->identifier != NULL)
        free(notificationData->identifier);

    if (notificationData->title != NULL)
        free(notificationData->title);

    if (notificationData->body != NULL)
        free(notificationData->body);

    if (notificationData->subtitle != NULL)
        free(notificationData->subtitle);

    if (notificationData->categoryIdentifier != NULL)
        free(notificationData->categoryIdentifier);

    if (notificationData->threadIdentifier != NULL)
        free(notificationData->threadIdentifier);

    if (notificationData->userInfo != NULL)
    {
        NSDictionary* userInfo = (__bridge_transfer NSDictionary*)notificationData->userInfo;
        userInfo = nil;
    }
}

void* _AddItemToNSDictionary(void* dict, const char* key, const char* value)
{
    NSDictionary* dictionary;
    if (dict != NULL)
        dictionary = (__bridge NSDictionary*)dict;
    else
    {
        dictionary = [[NSMutableDictionary alloc] init];
        dict = (__bridge_retained void*)dictionary;
    }

    NSString* k = [NSString stringWithUTF8String: key];
    NSString* v = value ? [NSString stringWithUTF8String: value] : @"";
    [dictionary setValue: v forKey: k];
    return dict;
}

void _ReadNSDictionary(void* csDict, void* nsDict, void (*callback)(void* csDcit, const char*, const char*))
{
    NSDictionary* dict = (__bridge NSDictionary*)nsDict;
    [dict enumerateKeysAndObjectsUsingBlock:^(id  _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
        NSString* k = key;
        if ([obj isKindOfClass: [NSString class]])
        {
            NSString* v = obj;
            callback(csDict, k.UTF8String, v.UTF8String);
        }
        else
        {
            NSError* error;
            NSData* data = [NSJSONSerialization dataWithJSONObject: obj options: NSJSONWritingPrettyPrinted error: &error];
            if (data)
            {
                NSString* v = [[NSString alloc] initWithData: data encoding: NSUTF8StringEncoding];
                callback(csDict, k.UTF8String, v.UTF8String);
            }
        }
    }];
}

#endif
